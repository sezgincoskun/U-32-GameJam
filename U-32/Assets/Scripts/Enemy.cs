using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myBody;


    [Header("Movement")]
    public float moveSpeed;
    private float minX, maxX;
    public float distance;
    public int direction;

    private bool patrol;

    private Transform playerPos;
    private Animator anim;

    [Header("Attack")]
    public Transform attackPos;
    public float attackRange;
    public LayerMask playerLayer;
    public int damage;

    public object Gismos { get; private set; }
    public AudioClip axeSwing;


    //AWAKE
    private void Awake()
    {

        anim = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").transform;
        myBody = GetComponent<Rigidbody2D>();

    }
    //START
    void Start()
    {
        maxX = transform.position.x + (distance);
        minX = maxX - distance;
    }

    //UPDATE
    void Update()
    {
        if (Mathf.Abs(transform.position.x - playerPos.position.x) <= 10f)
        {
            patrol = false;
        }
        else
        {
            patrol = true;
        }


    }

    //FIXED UPDATE
    private void FixedUpdate()
    {

        if (anim.GetBool("Die"))
        {
            myBody.velocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
            myBody.isKinematic = true;
            anim.SetBool("Attack", false);
            return;
        }

        if (myBody.velocity.x > 0)
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);
            anim.SetBool("Attack", false);
        }
        else if (myBody.velocity.x < 0)
            transform.localScale = new Vector2(-1f, transform.localScale.y);

        if (patrol)
        {
            switch (direction)
            {
                case -1:
                    if (transform.position.x > minX)
                        myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
                    else
                        direction = 1;

                    break;

                case 1:
                    if (transform.position.x < maxX)
                        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
                    else
                        direction = -1;

                    break;
            }
        }

        else
        {
            if (Vector2.Distance(playerPos.position, transform.position) >= 3f)
            {
                Vector3 playerDir = (playerPos.position - transform.position).normalized;

                if (playerDir.x > 0)
                    myBody.velocity = new Vector2(moveSpeed + 3f, myBody.velocity.y);
                else
                    myBody.velocity = new Vector2(-(moveSpeed + 3f), myBody.velocity.y);
            }
            else
            {
                myBody.velocity = new Vector2(0, myBody.velocity.y);
                anim.SetBool("Attack", true);
            }
        }
    }

    public void Attack()
    {
        myBody.velocity = new Vector2(0, myBody.velocity.y);

        //SoundManager.instance.PlaySoundFX(axeSwing, 0.3f);

        Collider2D attackPlayer = Physics2D.OverlapCircle(attackPos.position, attackRange, playerLayer);
        if (attackPlayer != null)
        {
            if (attackPlayer.tag == "Player")
            {
                attackPlayer.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
