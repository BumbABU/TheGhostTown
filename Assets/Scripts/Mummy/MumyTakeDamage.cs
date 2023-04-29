using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumyTakeDamage : MonoBehaviour
{
    [SerializeField]
    private HealthEnemy health;
    [SerializeField]
    private CowboyStatus cowboyStatus;
  /*  [SerializeField]
    private float mummyHealth = 100;*/
    private MummyFollow mummyFollow;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
   // private EnemyManager enemyManager;
    private bool isDeath = false;
    public bool IsDeath { get { return isDeath; } }
    private bool isTakeDamage = false;
    public bool IsTakeDamage { get { return isTakeDamage; } }
   
    private float foreceEffect;
    private void Start()
    {
        //enemyManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        mummyFollow = GetComponent<MummyFollow>();
       // health = GetComponent<HealthEnemy>();
    }

    private void FixedUpdate()
    {
        if (isTakeDamage)
        {
            StartCoroutine(changeIstakedamage());
        }
    }
    public void TakeDamage(float Dame)
    {
        if(cowboyStatus.IsDashingCut)
        {
            foreceEffect = cowboyStatus.ForeceEffectDash;
        }
        else
        {
            foreceEffect = cowboyStatus.ForeceEffectBullet;
        }
        rb.AddForce(mummyFollow.Distance.normalized * foreceEffect, ForceMode2D.Impulse);
        isTakeDamage = true;
        mummyFollow.IsFollowing = true;
        health.Health -= Dame;
       // HealthEnemy.health -= Dame;
        if (health.Health <= 0)
        {
            isDeath = true;
            Invoke("Destroy", 0.5f);
        }
    }

    private IEnumerator changeIstakedamage()
    {
       // rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(0.5f);
        isTakeDamage = false;
       // rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
