using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject kuisPanel;
    public GameObject player;
    public PlayerController playerController;
    public static bool isGameStarted;
    public GameObject startingText;
    public Animator anim;
    [SerializeField] private Health playerHealth;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
    }

    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (SwipeManager.tap)
        {
            anim.SetTrigger("Run");
            isGameStarted = true;
            Destroy(startingText);
        }
    }

    public void Revive()
    {
        anim.SetTrigger("Run");
        gameOver = false;
        gameOverPanel.SetActive(false);
        kuisPanel.SetActive(false);
        playerHealth.AddHealth(1);
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
