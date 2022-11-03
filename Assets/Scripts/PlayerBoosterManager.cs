using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosterManager : MonoBehaviour
{
    public GameObject player;
    public bool isInvisible = false;
    [SerializeField] private float timer;
    
    // Update is called once per frame
    void Update()
    {
        if (isInvisible)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                isInvisible = false;
                timer = 0;
                GetComponent<Collider>().isTrigger = false;
                player.GetComponent<PlayerController>().speed = 15;
                Debug.Log(player.GetComponent<PlayerController>().speed);
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            GetComponent<Collider>().isTrigger = true;
            player.GetComponent<PlayerController>().speed = 100;
            player.GetComponent<CapsuleCollider>().enabled = false;
            isInvisible = true;
        }
    }
}
