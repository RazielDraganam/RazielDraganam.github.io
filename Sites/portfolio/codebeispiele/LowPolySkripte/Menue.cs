using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void OnPlayButton()          // PlayButton MainMenue
        {
        // Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(1);      // Level laden
        }

    public void OnQuitButton()          // Beenden Button MainMenue
    {
        Application.Quit();             // Programm beenden, funktioniert nicht im Editor sondern nur im Spiel dann
    }

    public void OnPlayButtonLvl1()
    {
        SceneManager.LoadScene(2);      // Level 1
    }

    public void OnPlayButtonLvl2()
    {
        SceneManager.LoadScene(4);      // Level 2
    }

    public void OnPlayButtonLvl3()
    {
        SceneManager.LoadScene(6);      // level 3
    }

    public void OnPlayButtonEnde()
    {
        SceneManager.LoadScene(0);
    }

}
