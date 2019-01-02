using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public GameObject gameOverPanel;

    private static Game singleton; //The singleton pattern ensures that you only have one and only one item to the GameObject reference.
    //you want one game to track everything fromt he score, the robots left and the current wave

    [SerializeField]
    RobotSpawn[] spawns; //array of teleporters (that spawn robots at each wave)

    public int enemiesLeft; //counter

    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountDown;
    public bool isGameOver; //keeps track of whether the game is over or not


    //1 - init the single and call spawnRobots
    // Use this for initialization
    void Start () {
        singleton = this;
        SpawnRobots();

        //setup variables
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountDown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
    }

    // Update is called once per frame
    void Update () {
		
	}

    //2 Go throgh each RobotSpawn (teleporter) in the array and call the method SpawnRobot() to actually spawn a robot. 
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            Debug.Log("Spawn");
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft); //this sets the enemy count to latest value after each spawn
    }

    IEnumerator updateWaveTimer()
    {

        //check to see if the game is over, if it isn't then pause the script for 1 second before decremnting the waveCountdown and updating the UI
        // when the countdown hits 0, spawn more robots, reset the count down to 30 and how this message to the player saying more robots on the way
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountDown--;
            gameUI.SetWaveText(waveCountDown);

            //spawn next wave and restart count down
            if (waveCountDown == 0)
            {
                SpawnRobots();
                waveCountDown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }

    //This method is called when a robot is killed, it removes it from the count and updates the UI
    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

        //Give player bonus for clearing the wave before the time is done

        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    /// <summary>
    /// Give Player 10 points for killing a robot
    /// </summary>
    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    //This coroutine updates the score every single second whilst the game is running, the player gets 1 point per surving every second.
    IEnumerator increaseScoreEachSecond()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }

    //1 - Frees the mouse cursor so the player is able to select from the options on the gameOver menu
    public void OnGUI()
    {
        if (isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //2 - Called when game is over, timeScale set 0 stops the robots moving and disable all controls and shows the game over panel
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPanel.SetActive(true);
    }

    //3 - used to restart the game by loading up the battle scence
    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(true);
    }

    //4 - Quits application only from normal build not from within unity
    public void Exit()
    {
        Application.Quit();
    }

    //5 - loads the scnce for the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
    }
}

