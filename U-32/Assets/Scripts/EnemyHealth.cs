using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    public int health = 50;
    private Animator anim;
    private Rigidbody2D rb;

    public EnemyHealthBar enemyHealthBar;

    void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDamage(int Damage)
    {
        health -= Damage;
        enemyHealthBar.SetHealth(health);

        if (health <= 0)
        {
            anim.SetBool("Die", true);
            GetComponent<Collider2D>().enabled = false;
            rb.isKinematic = true;
            Destroy(gameObject, 2);
            Collect.instance.AddScore(35);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            takeDamage(50);
        }

        if (collision.CompareTag("Flame"))
        {
            takeDamage(50);
        }
    }

}