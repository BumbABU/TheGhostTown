using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedamage : MonoBehaviour
{
    [SerializeField] 
    private HealthEnemy health;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private EnemyManager enemyManager;
    private bool isDeath = false;
    public bool IsDeath { get { return isDeath; } }
    private float foreceEffect;
    private void Start()
    {
       enemyManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
      //  health = GetComponent<HealthEnemy>();
    }

    private void FixedUpdate()
    {
        if (enemyManager.IsTakedamage)
        {
            StartCoroutine(changeIstakedamage());
        }
    }
    public void TakeDamage(float Dame)
    {
        if (cowboyStatus.IsDashingCut)
        {
            foreceEffect = cowboyStatus.ForeceEffectDash;
        }
        else
        {
            foreceEffect = cowboyStatus.ForeceEffectBullet;
        }
        rb.AddForce(enemyManager.Distance.normalized * foreceEffect, ForceMode2D.Impulse);
        enemyManager.IsTakedamage = true;
        enemyManager.IsfollowCowboy = true;
        health.Health -= Dame;
       // HealthEnemy.health -= Dame;
        if (health.Health <= 0)
        {
            isDeath = true;
            rb.gravityScale = 200;
            Invoke("Destroy", 1f);
        }
    }

    private IEnumerator changeIstakedamage()
    {
       // rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(0.5f);
        enemyManager.IsTakedamage = false;
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
