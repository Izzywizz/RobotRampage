using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    // Scenes
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";

    // Gun Type
    public const string Pistol = "Pistol";
    public const string Shotgun = "Shotgun";
    public const string AssaultRifle = "AssaultRifle";

    // Robot Types
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";

    //Pickup Types
    public const int PickUpPistolAmmo = 1;
    public const int PickUpAssaultRifleAmmo = 2;
    public const int PickUpShotgunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;

    // Misc
    public const string Game = "Game";
    public const float CameraDefaultZoom = 60f;

    //readonly here means A static readonly variable is a reference, and consequently a lookup is performed any time this variable is accessed
    //please refer to this article: A static readonly variable is a reference, and consequently a lookup is performed any time this variable is accessed
    public static readonly int[] AllPickupTypes = new int[5]
    {
        PickUpPistolAmmo,
        PickUpAssaultRifleAmmo,
        PickUpShotgunAmmo,
        PickUpHealth,
        PickUpArmor
    };
}