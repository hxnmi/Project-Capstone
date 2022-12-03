using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0;
    
    [SerializeField] Text coinsText;
    [SerializeField] private AudioSource coinSFX;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            coinSFX.Play();
            Destroy(col.gameObject);
            coins++;
            coinsText.text = "" + coins;
        }
    }
}
