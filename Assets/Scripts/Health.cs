using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource deadSFX;
    public Animator anim;
    public float currentHealth { get; private set; }
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        hitSFX.Play();
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            anim.SetTrigger("Dead");
            deadSFX.Play();
            PlayerManager.gameOver = true;
            Time.timeScale = 0;
        }
    }
    
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
