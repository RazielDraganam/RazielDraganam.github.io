using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Level2 : Level
{

    int questProgress = 0;
   // string tagFuerQuest = "Kette";

    new float roteGem;
    new float grueneGem;
    new float blaueBlume;
    new float weisseBlume;
    float Werkzeug;

    //new CapsuleCollider collider;

    string questName = "Sammle Material";
    readonly int maxQuestProgress = 32;

    [SerializeField]
    TextMeshProUGUI progressTextUI;

    [SerializeField]
    TextMeshProUGUI questNameUI;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.tag = "roteGem";
        gameObject.tag = "grueneGem";
        gameObject.tag = "blaueBlume";
        gameObject.tag = "weisseBlume";
        gameObject.tag = "Messer";
        gameObject.tag = "dorfJuwelier";

        Hacke = true;

        ResetCrystals();
        questNameUI.text = questName;
        UpdateUI();

    }


    private void OnCollisionEnter(Collision collision)

    {

        // Aufsammeln der Hacke
        if (collision.gameObject.tag.Equals("Messer"))
        {
            Debug.Log("Messer aufgesammelt");
            Destroy(collision.gameObject);
            Messer = true;
            Werkzeug++;
            UpdateUI();
        }

        //  Debug.Log("Player: " + collision.gameObject.tag);


        // If Abfrage mit Messer wegen QuestItem
        if (Messer == true)

        {
            //Checken ob schon 15 rote gems, maximal index von 15 angeben
            if (collision.gameObject.tag.Equals("roteGem") && (roteGem <= 15))
            {
                Debug.Log("rote gem gesammelt");
                questProgress++;
                roteGem++;
                Destroy(collision.gameObject);
                UpdateUI();
            }


            //checken ob schon 5 grueneGems, maximal index von 5 angeben
            if (collision.gameObject.tag.Equals("grueneGem") && (grueneGem <= 5))
            {
                Debug.Log("gruene Gem gesammelt");
                questProgress++;
                grueneGem++;
                Destroy(collision.gameObject);
                UpdateUI();
            }

            //checken ob schon 10 blaue Blumen, maximal index von 10 angeben
            if (collision.gameObject.tag.Equals("blaueBlume") && (blaueBlume <= 10))
            {
                Debug.Log("blaue Blume gesammelt");
                questProgress++;
                blaueBlume++;
                Destroy(collision.gameObject);
                UpdateUI();
            }

            //checken ob schon 2 weisse blume, maximal index von 2 angeben
            if (collision.gameObject.tag.Equals("weisseBlume") && (weisseBlume <= 5))
            {
                Debug.Log("weisse Blume gesammelt");
                questProgress++;
                weisseBlume++;
                Destroy(collision.gameObject);
                UpdateUI();
            }

        }
        // else


        if (questProgress == 32)
        {
            Kette = true;
            //Level komplett, canvas Level 3 laden
            questProgress++;
            SceneManager.LoadScene(5);
            UpdateUI();
        }

    }

    void UpdateUI()
    {
        progressTextUI.text = $"{questProgress}/{maxQuestProgress}\n" +
                                $"Messer: {Werkzeug}/1\n" +
                                $"rote Gem: {roteGem}/15\n" +
                                $"grüne Gem: {grueneGem}/5\n" +
                                $"blaue Blume: {blaueBlume}/10\n" +
                                $"weisse Blume: {weisseBlume}/2";
    }


}  