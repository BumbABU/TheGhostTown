using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Shooting shooting;
    public Transform shootingPoint;
    private Rigidbody2D rb;
    public bool IsRight;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (IsRight ? transform.right : -transform.right) * shooting.BulletRate;
       //hooting = GetComponent<Shooting>();
    }
    private void Update()
    {
        if (Vector2.Distance(shootingPoint.position, transform.position) > shooting.DistanceBullet)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Takedamage enemy = collision.GetComponent<Takedamage>();
            EnemyManager enemy1 = collision.GetComponent<EnemyManager>();

            if (enemy != null && !enemy1.IsUntilSkill)
            {
                enemy.TakeDamage(shooting.DamageBullet);
                Destroy(gameObject);

            }
        }
        else if (collision.CompareTag("mummy"))
        {
            MumyTakeDamage mummy = collision.GetComponent<MumyTakeDamage>();
            if(mummy != null)
            {
                mummy.TakeDamage(shooting.DamageBullet);
                Destroy(gameObject);
            }
        }
        else if(collision.CompareTag("Devil"))
        {
            DevilTakeDamage devil = collision.GetComponent<DevilTakeDamage>();
            if(devil != null)
            {
                devil.TakeDamage(shooting.DamageBullet);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("boss")) 
        {
            BossTakeDamage boss = collision.GetComponent<BossTakeDamage>();
            if(boss != null)
            {
                boss.TakeDamage(shooting.DamageBullet);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }

    }

   
}   
