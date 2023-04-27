using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTakeDamage : MonoBehaviour
{
    [SerializeField]
    private CowboyStatus cowboyStatus;
    [SerializeField]
    private float devilHealth = 100;
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
        Debug.Log(devilHealth);
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
        devilHealth -= Dame;
        if (devilHealth <= 0)
        {
            isDeath = true;
            rb.gravityScale = 20f;
            collider.isTrigger = false;
            Invoke("Destroy", 3f);
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
