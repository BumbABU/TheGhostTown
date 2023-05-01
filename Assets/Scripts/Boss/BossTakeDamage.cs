using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDamage : MonoBehaviour
{
    [SerializeField]
    private HealthEnemy health;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    /*  [SerializeField]
      private float mummyHealth = 100;*/
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
        rb = GetComponent<Rigidbody2D>();
        // health = GetComponent<HealthEnemy>();
    }

    private void FixedUpdate()
    {
        Debug.Log(health.Health);
        if (isTakeDamage)
        {
            StartCoroutine(changeIstakedamage());
        }
    }
    public void TakeDamage(float Dame)
    {
       // rb.AddForce(mummyFollow.Distance.normalized * foreceEffect, ForceMode2D.Impulse);
        isTakeDamage = true;
        health.Health -= Dame;
        if (health.Health <= 0)
        {
            isDeath = true;
            Invoke("Destroy", 2f);
        }
    }

    private IEnumerator changeIstakedamage()
    {
        yield return new WaitForSeconds(0.5f);
        isTakeDamage = false;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
