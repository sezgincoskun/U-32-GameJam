using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;
    private bool grounded;
    public Vector3 range;
    public AudioClip jump;

    private Rigidbody2D rb;
    private Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        CheckCollisionForJump();
    }

    void Movement()
    {
        moveInput = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput, rb.velocity.y);

        if (moveInput > 0 && !facingRight || moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }

    void CheckCollisionForJump()
    {
        Collider2D bottomHit = Physics2D.OverlapBox(groundCheck.position, range, 0, groundLayer);

        if (bottomHit != null)
        {
            if (bottomHit.gameObject.tag == "Ground" && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                SoundManager.instance.PlaySoundFX(jump, 0.3f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(groundCheck.position, range);
    }
}
