using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static bool isGameActive = false, isGameFinished = false;
    public static int currentLevelIndex = 0;
    public static string arrowLocation = "Arrows/Arrow";
    public static int sword_Index = 0;
    public static int greatSword_Index = 0;
    public static string magicLocation = "Magics/Magic";



    public static float archer_cd = 0.5f; public static int arrowQuantity = 0;
    public static float knight_cd = 0.5f;
    public static float greatSworder_cd = 1f;
    public static float wizard_cd = 0.7f;
    public static float soldier_cd = 0.05f;
}
