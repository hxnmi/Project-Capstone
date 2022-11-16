using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject panelKuis;
    public GameObject gameOverpanel;
    public GameObject youLose;
    public KuisManager kuisManager;
    public CoinCollector coinCollector;

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

    public void MainMenuKalah()
    {
        SceneManager.LoadScene("MainMenu");
        if (PlayerPrefs.HasKey("score"))
        {
            var earncoin = PlayerPrefs.GetInt("score");
            var coinCollectorCoins = earncoin + coinCollector.coins;
            PlayerPrefs.SetInt("coins", coinCollectorCoins);
        }
        else
        {
            PlayerPrefs.SetInt("coins", coinCollector.coins);
        }
    }
}
