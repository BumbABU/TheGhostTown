using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletRate;

    [SerializeField]
    private int damageBullet;
    [SerializeField]
    private float distanceBullet;
    public Transform shootingPoint;
    private Rigidbody2D rb;
    public bool IsRight;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity =(IsRight? transform.right : -transform.right) * bulletRate;

    }
    private void Update()
    {
        if (Vector2.Distance(shootingPoint.position, transform.position) > distanceBullet)
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
                enemy.TakeDamage(damageBullet);
                Destroy(gameObject);

            }
        }
        else if (collision.CompareTag("mummy"))
        {
            MumyTakeDamage mummy = collision.GetComponent<MumyTakeDamage>();
            if(mummy != null)
            {
                mummy.TakeDamage(damageBullet);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            Debug.Log("3333333333333333333333333333333");
            Destroy(gameObject);
        }

    }

   
}   
