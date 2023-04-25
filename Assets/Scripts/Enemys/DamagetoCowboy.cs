using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagetoCowboy : MonoBehaviour
{
    private UntillSkill untillSkill;
    [SerializeField]
    private BoxCollider2D collider2d;
    [SerializeField]
    private EdgeCollider2D eglecollider2d;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private Takedamage takedamage;
    private EnemyManager enemyManager;
    private float timertakeDamage;
    [SerializeField]
    private float delayTakedamage =0.5f;

    private bool isDamagetoCowboy = false;
    public bool IsDamgetoCowboy { get { return isDamagetoCowboy; } set { IsDamgetoCowboy = value; } }
    [SerializeField]
    private int defaultGravityScale;


    private void Update()
    {
        Debug.Log(rb.gravityScale);
        if(isDamagetoCowboy && enemyManager.Isattacking)
        {
            DamageToCowboy();
        }
        if(isDamagetoCowboy && enemyManager.IsUntilSkill)
        {
          if(cowboyStatus.IsDashingCut)
            {
                cowboyStatus.cowboyTakedamage((enemyManager.SkillDamage)/2);
                
            }
          else if (!cowboyStatus.IsDashingCut)
            {
                cowboyStatus.cowboyTakedamage(enemyManager.SkillDamage);
            }
        }
    }
    private void Start()
    {
        untillSkill = GetComponent<UntillSkill>();
        takedamage = GetComponent<Takedamage>();
        enemyManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        eglecollider2d = GetComponent<EdgeCollider2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {

            if (!enemyManager.IsUntilSkill && !cowboyStatus.IsDashingCut&&!takedamage.IsDeath)
            {
                isDamagetoCowboy = true;
                enemyManager.Isattacking = true;
                //enemyManager.Speed = 0.5f;
            }
            else if (enemyManager.IsUntilSkill&& !takedamage.IsDeath)
            {
                isDamagetoCowboy = true;
                collider2d.isTrigger = true;
                //rb.gravityScale = -5;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {
            enemyManager.Isattacking = false;
           // cowboyStatus.IsTakeDamage = false;
            isDamagetoCowboy = false;
            collider2d.isTrigger = false;
            rb.gravityScale = defaultGravityScale;
           /* if(enemyManager.IsUntilSkill)
            {
                rb.gravityScale = untillSkill.UntillSkillScale;
            }*/
        }
    }

    private void DamageToCowboy()
    {
        Debug.Log("Run time");
        timertakeDamage += Time.deltaTime;
        if (timertakeDamage < delayTakedamage) return;
        timertakeDamage = 0;
        cowboyStatus.cowboyTakedamage(enemyManager.DefaultDamage);
       
    }
}
