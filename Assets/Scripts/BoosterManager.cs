using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterManager : MonoBehaviour
{
    public Collider player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("nabrak");
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<PlayerController>().speed = 50;
        }
    }
}
