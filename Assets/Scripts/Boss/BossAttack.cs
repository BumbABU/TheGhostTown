using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private BossFollow bossFollow;
    private BossTakeDamage bossTakeDamage;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private bool isAttack = false;
    public bool IsAttack { get { return isAttack; } }
    private float timertakeDamage = 0;
    [SerializeField]
    private float delayTakedamage = 2;
    [SerializeField]
    private float bossDamage = 5f;
    [SerializeField]
    private Collider2D collider1;
    [SerializeField]
    private Collider2D collider2;

    [SerializeField]
    private Rigidbody2D rb;
    private float originalRb;
    private void Awake()
    {
        bossTakeDamage = GetComponent<BossTakeDamage>();
        bossFollow = GetComponent<BossFollow>();
        collider1 = GetComponent<Collider2D>();
        collider2 = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        originalRb = this.rb.gravityScale;
    }

    private void Update()
    {
        if (isAttack)
        {
            AttackCowboy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Cowboy"))
        {
            if ( bossFollow.IsFollowing && !cowboyStatus.IsDashingCut && !bossTakeDamage.IsDeath)
            {
                isAttack = true;
            }
        }
        if (collision.CompareTag("mummy"))
        {
            collider1.isTrigger = true;
            collider2.isTrigger = true;
            rb.gravityScale = 0;
            
        }
        if (collision.CompareTag("Devil"))
        {
            collider1.isTrigger = true;
            collider2.isTrigger = true;
            rb.gravityScale = 0;

        }
        if (collision.CompareTag("Enemy"))
        {
            collider1.isTrigger = true;
            collider2.isTrigger = true;
            rb.gravityScale = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {
            isAttack = false;
        }
        if (collision.CompareTag("mummy"))
        {
            collider1.isTrigger = false;
            collider2.isTrigger = false;
            rb.gravityScale = originalRb;

        }
        if (collision.CompareTag("Devil"))
        {
            collider1.isTrigger = false;
            collider2.isTrigger = false;
            rb.gravityScale = originalRb;

        }
        if (collision.CompareTag("Enemy"))
        {
            collider1.isTrigger = false;
            collider2.isTrigger = false;
            rb.gravityScale = originalRb;

        }
    }

    private void AttackCowboy()
    {
        timertakeDamage += Time.deltaTime;
        if (timertakeDamage < delayTakedamage) return;
        timertakeDamage = 0;
        cowboyStatus.cowboyTakedamage(bossDamage);

    }
}
