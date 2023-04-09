using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator anim;
    public Transform attackPos;
    public LayerMask enemyLayer;
    public GameObject hitAnim;
    public AudioClip swordHit;

    public float attackRange;
    public int damage;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        Attack();
    }

    void DamageIt()
    {
        Collider2D[] attackEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);

        for (int i = 0; i < attackEnemies.Length; i++)
        {
            SoundManager.instance.PlaySoundFX(swordHit, 0.3f);

            if (attackEnemies[i].GetComponent<EnemyHealth>().health > 0)
            {
                attackEnemies[i].GetComponent<EnemyHealth>().takeDamage(damage);
                Instantiate(hitAnim, attackPos.position, Quaternion.identity);
                SoundManager.instance.PlaySoundFX(swordHit, 0.3f);
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Attack");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
