using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject player;
    public PlayerController playerController;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void Revive()
    {
        Debug.Log("Wow");
        gameOver = false;
        gameOverPanel.SetActive(false);
        Collider[] hitColliders = Physics.OverlapBox(player.transform.position, new Vector3(3, 3, 50), player.transform.rotation);
        foreach (var coll in hitColliders)
        {
            if (coll.CompareTag("Obstacle"))
            {
                Destroy(coll.gameObject);
            }
        }

        player.GetComponent<PlayerController>().speed = 10;
        Time.timeScale = 1;
    }
}
