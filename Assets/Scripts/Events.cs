using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject panelKuis;
    public GameObject gameOverpanel;
    public KuisManager kuisManager;

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void KuisRevive()
    {
        gameOverpanel.SetActive(false);
        kuisManager.RandomSoal();
        panelKuis.SetActive(true);
    }
}
