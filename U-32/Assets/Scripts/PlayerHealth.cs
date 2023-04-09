using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int maxHealth = 100;
    public int currentHealth;

    public AudioClip hit;
    public AudioClip trapSound;
    public AudioClip healSound;


    private Animator anim;
    private Rigidbody2D rb;


    public HealthBar healthBar;

    public Text healthText;

    PlayerMovement playerMovement;

    void Awake()
    {
        instance = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (currentHealth < 1)
        {
            StartCoroutine(PlayerDeath());
        }
    }


    IEnumerator PlayerDeath()
    {
        anim.SetBool("Die", true);
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void TakeDamage(int damage)
    {
             SoundManager.instance.PlaySoundFX(hit, 0.3f);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Trap"))
        {
            SoundManager.instance.PlaySoundFX(trapSound, 0.3f);
            currentHealth -= 15;
            healthBar.SetHealth(currentHealth);
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        if (target.CompareTag("Flame"))
        {
            currentHealth -= 100;
            healthBar.SetHealth(currentHealth);
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        }

        if (target.CompareTag("HealthPotion"))
        {
            SoundManager.instance.PlaySoundFX(healSound, 0.4f);
            if (currentHealth < maxHealth)
            {
                currentHealth += 25;

                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
            }
            
            healthBar.SetHealth(currentHealth);
            healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
            Destroy(target.gameObject, 0.01f);
        }
    }
}



