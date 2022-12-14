using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosterManager : MonoBehaviour
{
    public GameObject player;
    public bool isInvisible = false;
    [SerializeField] private float timer;
    [SerializeField] private AudioSource boosterSFX;
    
    // Update is called once per frame
    void Update()
    {
        if (isInvisible)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                player.GetComponent<PlayerController>().speed = 15;
                isInvisible = false;
                timer = 0;
                GetComponent<Collider>().isTrigger = false;
                Collider[] hitColliders = Physics.OverlapBox(player.transform.position, new Vector3(10, 10, 100), player.transform.rotation);
                foreach (var coll in hitColliders)
                {
                    if (coll.CompareTag("Obstacle"))
                    {
                        coll.GetComponent<BoxCollider>().isTrigger = false;
                    }
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            // GetComponent<Collider>().isTrigger = true;
            boosterSFX.Play();
            player.GetComponent<PlayerController>().speed = 100;
            Collider[] hitColliders = Physics.OverlapBox(player.transform.position, new Vector3(10, 10, 5100), player.transform.rotation);
            foreach (var coll in hitColliders)
            {
                if (coll.CompareTag("Obstacle"))
                {
                    Debug.Log(coll);
                    coll.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            // player.GetComponent<CapsuleCollider>().enabled = false;
            isInvisible = true;
        }
    }
}
