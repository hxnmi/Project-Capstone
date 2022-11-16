using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0;
    
    [SerializeField] Text coinsText;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            coins++;
            coinsText.text = "" + coins;
        }
    }
}
