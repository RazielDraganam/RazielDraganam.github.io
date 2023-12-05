using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // QuestItems auf null setzen
    public bool Hacke = false;
    public bool Messer = false;
    public bool Spitzhacke = false;

    // Sammelitems
    public static double roteGem = 0;
    public static double grueneGem = 0;
    public static double blaueBlume = 0;
    public static double weisseBlume = 0;
    public static double blaueGem = 0;

    //Questbelohnung
    public static bool Ohrring = false;
    public static bool Kette = false;
    public static bool Verlobungsring = false;

    public static void ResetCrystals()
    {
        // spielerinventar jedes mal auf null setzen, Questgegenstände bleiben erhalten
        roteGem = 0;
        grueneGem = 0;
        blaueBlume = 0;
        weisseBlume = 0;
        blaueGem = 0;
    }
}
