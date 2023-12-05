using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

    //Standartvorgabe Level
    /*
     *     /* Inventar auflistung aller M�glichkeiten
     * - Spitzhacke (zu finden in Epoche 3, bleibt im Inventar)         (Tag: Spitzhacke) UI: SpitzhackeUI
     * - rote Gems (zur�cksetzen bei neuer Epoche)                      (Tag: roteGem)
     * - Gr�ne Gems (zur�cksetzen bei neuer Epoche)                     (Tag: grueneGem)
     * - blaue Blume (zur�cksetzen bei neuer Epoche)                    (Tag: blaueBlume)
     * - wei�e Blume (zur�cksetzen bei neuer Epoche)                    (Tag: weisseBlume)
     * - blaue Gems (Bergbau)                                           (Tag: blaueGem)
     *  - Verlobungsring bei Epoche 3 Questabschluss
     *  Level 3:    Spitzhacke (im UI einblenden)
     *              grueneGem 5 St�ck
     *              weisseBlume 2 St�ck
     *              blaueGem 5 St�ck
     */

public class Level3 : Level
{

    int questProgress = 0;
    // string tagFuerQuest = "Verlobungsring";

    new float grueneGem;
    new float weisseBlume;
    new float blaueGem;
    float Werkzeug;

    //new CapsuleCollider collider;

    string questName = "Sammle Material";
    readonly int maxQuestProgress = 13;

    [SerializeField]
    TextMeshProUGUI progressTextUI;

    [SerializeField]
    TextMeshProUGUI questNameUI;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "grueneGem";
        gameObject.tag = "weisseBlume";
        gameObject.tag = "Spitzhacke";
        gameObject.tag = "dorfJuwelier";
        gameObject.tag = "blaueGem";

        Hacke = true;
        Messer = true;

        ResetCrystals();
        questNameUI.text = questName;
        UpdateUI();

    }


    private void OnCollisionEnter(Collision collision)

    {

        // Aufsammeln der Hacke
        if (collision.gameObject.tag.Equals("Spitzhacke"))
        {
            Debug.Log("Spitzhacke aufgesammelt");
            Destroy(collision.gameObject);
            Spitzhacke = true;
            questProgress++;
            Werkzeug++;
            UpdateUI();
        }

        //  Debug.Log("Player: " + collision.gameObject.tag);


        // If Abfrage mit Messer wegen QuestItem
        if (Spitzhacke == true)

        {

            if (collision.gameObject.tag.Equals("blaueGem") && (blaueGem <= 5) /*&& questProgress <= 10*/)
            {
                Debug.Log("blaue gem gesammelt");
                questProgress++;
                blaueGem++;
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


            //checken ob schon 2 weisse blume, maximal index von 2 angeben
            if (collision.gameObject.tag.Equals("weisseBlume") && (weisseBlume <= 2))
            {
                Debug.Log("weisseBlume gesammelt");
                questProgress++;
                weisseBlume++;
                Destroy(collision.gameObject);
                UpdateUI();
            }

        }
        // else


        if (questProgress == 13)
        {
            Verlobungsring = true;
            questProgress++;
            SceneManager.LoadScene(7);
            UpdateUI();
        }

    }

    void UpdateUI()
    {
        progressTextUI.text = $"{questProgress}/{maxQuestProgress}\n" +
                                $"Spitzhacke: {Werkzeug}/1\n" +
                                $"gr�ne Gem: {grueneGem}/5\n" +
                                $"weisse Blume: {weisseBlume}/2\n" +
                                $"blaue Gem: {blaueGem}/5";
    }


}


