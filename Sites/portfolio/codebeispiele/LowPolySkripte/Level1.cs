using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1 : Level
{
    int questProgress = 0;
    string tagFuerQuest = "Ohrring";

    new float roteGem;
    new float grueneGem;
    float Werkzeug;

    string questName = "Sammle Material";
    readonly int maxQuestProgress = 13;

    [SerializeField]
    TextMeshProUGUI progressTextUI;

    [SerializeField]
    TextMeshProUGUI questNameUI;

    void Start()
    {
         gameObject.tag = "roteGem";
         gameObject.tag = "grueneGem";
         gameObject.tag = "Hacke";
         gameObject.tag = "dorfJuwelier";

        ResetCrystals();
        questNameUI.text = questName;
        UpdateUI();
    }

    private void OnCollisionEnter(Collision collision)

    {
        // Aufsammeln der Hacke
         if (collision.gameObject.tag.Equals("Hacke"))
         {
            questProgress++;
            Werkzeug++;
            Destroy(collision.gameObject);
            Hacke = true;
            UpdateUI();
         }

        // If Abfrage mit Hacke wegen QuestItem als Voraussetzung
        if (Hacke == true)   
            {
                //Checken ob schon 10 rote gems, maximal index von 10 angeben
                if (collision.gameObject.tag.Equals("roteGem") && (roteGem <= 10))
                {
                    questProgress++;
                    roteGem++;
                    Destroy(collision.gameObject);
                    UpdateUI();
                }

                //checken ob schon 2 grueneGems, maximal index von 2 angeben
                if (collision.gameObject.tag.Equals("grueneGem") && (grueneGem <= 2) )
                {
                    questProgress++;
                    grueneGem++;
                    Destroy(collision.gameObject);
                    UpdateUI();
                }
            }  

            // Wenn Questfortschritt erreicht
            if (questProgress == 13)
                {
                    Ohrring = true;
                    questProgress++;
                    SceneManager.LoadScene(3);
                    UpdateUI();
                }
    }
    
    void UpdateUI()
    {
        progressTextUI.text = $"{questProgress}/{maxQuestProgress}\n" +
                                $"Hacke: {Werkzeug}/1\n" +
                                $"rote Gem: {roteGem}/10\n" +
                                $"grüne Gem: {grueneGem}/2";
    }
}
