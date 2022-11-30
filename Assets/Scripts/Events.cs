using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject panelKuis;
    public GameObject gameOverpanel;
    public KuisManager kuisManager;
    public CoinCollector coinCollector;
    public PlayerController player;

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
        if (PlayerPrefs.HasKey("coins"))
        {
            var earncoin = PlayerPrefs.GetInt("coins");
            var coinCollectorCoins = earncoin + coinCollector.coins;
            PlayerPrefs.SetInt("coins", coinCollectorCoins);
        }
        else
        {
            PlayerPrefs.SetInt("coins", coinCollector.coins);
        }
        if (PlayerPrefs.HasKey("score"))
        {
            var scoretemp = PlayerPrefs.GetInt("score");
            if (player.score > scoretemp)
            {
                PlayerPrefs.SetInt("score", player.score);
            }
            else
            {
                PlayerPrefs.SetInt("score", scoretemp);
            }
        }
        else
        {
            PlayerPrefs.SetInt("score", player.score);
        }
        SceneManager.LoadScene("MainMenu");
        
    }
}
