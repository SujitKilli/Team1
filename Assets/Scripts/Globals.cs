using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static string x = "js1";
    public static string y = "js0";
    public static string a = "js3";
    public static string b = "js2";
    public static string ok = "js9";
    public static string globalMenu = "js3";
    public static string ver = "Horizontal";
    public static string hor = "Vertical";

    public static bool isChicken = false;
    public static bool isSteak = false;
    public static bool isFish = false;

    public static bool isInDoor = false;
    public static bool isInDoorBtn = false;

    public static GameObject sitter = null;
    public static bool sat = false;

    public static GameObject boatSitter = null;
    public static bool boatsat = false;

    public static bool isglobalVisible = false;
    public static bool hideOutline = false;

    public static bool isTeleport = false;

    public static bool isFly = false;

    public static bool isInv = false;

    public static float ypos = 0f;
    
    public static List<GameObject> inventory = new List<GameObject>();
    public static int invCounter = 0;
    public static int inventoryLimit = 3;   

    public static List<GameObject> boundaries = new List<GameObject>();

    public static void ToggleBoundaries(bool show){
        foreach (GameObject b in boundaries) {
            b.SetActive(show);
        }
    }
}
