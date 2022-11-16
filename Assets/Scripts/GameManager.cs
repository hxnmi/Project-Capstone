using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int coin;
    public static Material playerSkin;
    public int coins;

    public Text text;

    public List<Text> price;
    public List<Image> coinImage;
    public List<Button> equipButton;
    public List<int> harga;

    // Start is called before the first frame update
    void Start()
    {
        coins = LoadScore();
        text.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Beli(int idx)
    {
        Debug.Log("Beli");
        if (coins >= harga[idx])
        {
            coins -= harga[idx];
            text.text = coins.ToString();
            price[idx].gameObject.SetActive(false);
            coinImage[idx].gameObject.SetActive(false);
            equipButton[idx].gameObject.SetActive(true);
        }
    }

    public void equip(Material skin)
    {
        playerSkin = skin;
    }

    int LoadScore(int defaultValue = 0){
        if(PlayerPrefs.HasKey("coins"))
            return PlayerPrefs.GetInt("coins");
        return defaultValue;
    }
}
