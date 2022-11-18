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
    public string PlayerPrefString;

    public Text text;

    public List<Text> price;
    public List<Image> coinImage;
    public List<Button> equipButton;
    public List<int> harga;
    public List<int> Skin;

    // Start is called before the first frame update
    void Start()
    {
        coins = LoadScore();
        text.text = coins.ToString();
        PlayerPrefString = PlayerPrefs.GetString("Baju");
        StringToList(PlayerPrefString, "+");
        for (int i = 0; i < Skin.Count; i++)
        {
            price[Skin[i]].gameObject.SetActive(false);
            coinImage[Skin[i]].gameObject.SetActive(false);
            equipButton[Skin[i]].gameObject.SetActive(true);
        }
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
            if (PlayerPrefs.HasKey("Baju"))
            {
                var HavingSkin = PlayerPrefs.GetString("Baju");
                var stringHavingSkin = HavingSkin + idx.ToString() + "+";
                PlayerPrefs.SetString("Baju", stringHavingSkin);
            }
            else
            {
                PlayerPrefs.SetString("Baju", idx.ToString() + "+");
            }
        }
    }

    public void equip(Material skin)
    {
        playerSkin = skin;
    }

    int LoadScore(){
        int defaultValue = 0;

        if(PlayerPrefs.HasKey("coins"))
            return PlayerPrefs.GetInt("coins");
        
        defaultValue = PlayerPrefs.GetInt("coins");
        return defaultValue;
    }

    void StringToList(string message, string seperator)
    {
        Skin.Clear();
        string tok = "";
        foreach(char character in message)
        {
            tok = tok + character;
            if (tok.Contains(seperator))
            {
                tok = tok.Replace(seperator, "");
                Skin.Add(int.Parse(tok));
                tok = "";
            }
        }
    }
}
