using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject panelKuis;
    public GameObject gameOverpanel;
    public KuisManager kuisManager;
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void KuisRevive()
    {
        gameOverpanel.SetActive(false);
        kuisManager.RandomSoal();
        panelKuis.SetActive(true);
    }
}
