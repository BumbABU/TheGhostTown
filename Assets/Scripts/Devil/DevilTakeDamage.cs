using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTakeDamage : MonoBehaviour
{
    private HealthEnemy health;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private Distance devilDistance;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private bool isDeath = false;
    public bool IsDeath { get { return isDeath; } }
    private bool isTakeDamage = false;
    public bool IsTakeDamage { get { return isTakeDamage; } }
    [SerializeField]
    private Collider2D collider;

    private float foreceEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        devilDistance = GetComponent<Distance>();
        collider = GetComponent<Collider2D>();
        health = GetComponent<HealthEnemy>();
    }

    private void FixedUpdate()
    {
        if (isTakeDamage)
        {
            StartCoroutine(changeIstakedamage());
        }
    }

    private void Update()
    {
        Debug.Log(health.Health);
    }
    public void TakeDamage(float Dame)
    {
        
      /*  if (cowboyStatus.IsDashingCut)
        {
            foreceEffect = cowboyStatus.ForeceEffectDash;
        }
        else
        {
            foreceEffect = cowboyStatus.ForeceEffectBullet;
        }
        rb.AddForce(devilDistance.DisTance.normalized * foreceEffect, ForceMode2D.Impulse);*/
        isTakeDamage = true;
        health.Health -= Dame;
        if (health.Health <= 0)
        {
            isDeath = true;
            rb.gravityScale = 200f;
            collider.isTrigger = false;

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
