using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttack : MonoBehaviour
{
    private MumyTakeDamage mummyTakeDamage;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private bool isAttack = false;
    public bool IsAttack { get { return isAttack; } }
    private float timertakeDamage = 0;
    [SerializeField]
    private float delayTakedamage = 0.005f;
    [SerializeField]
    private float mummyDamage = 5f;
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private Rigidbody2D rb;
    private float originalRb;

    private void Awake()
    {
        mummyTakeDamage = GetComponent<MumyTakeDamage>();
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        originalRb = rb.gravityScale;
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
            if (!cowboyStatus.IsDashingCut && !mummyTakeDamage.IsDeath)
            {
                isAttack = true;
            }
        }
/*        if (collision.CompareTag("mummy"))
        {
            collider.isTrigger = true;
            rb.gravityScale = 0;

        }*/
/*        if (collision.CompareTag("Enemy"))
        {
            collider.isTrigger = true;
            rb.gravityScale = 0;

        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {
            isAttack = false;
        }
        if (collision.CompareTag("mummy"))
        {
            collider.isTrigger = false;
            rb.gravityScale = originalRb;

        }
        /*        if (collision.CompareTag("Enemy"))
                {
                    collider.isTrigger = false;
                    rb.gravityScale = originalRb;

                }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mummy"))
        {
            collider.isTrigger = true;
            rb.gravityScale = 0;

        }
    }

   
    private void AttackCowboy()
    {
        timertakeDamage += Time.deltaTime;
        if (timertakeDamage < delayTakedamage) return;
        timertakeDamage = 0;
        cowboyStatus.cowboyTakedamage(mummyDamage);

    }
}
