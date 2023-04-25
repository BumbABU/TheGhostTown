using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationscripts : MonoBehaviour
{
    private Takedamage takedamage;
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } }
    private EnemyManager enemyManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
        takedamage = GetComponent<Takedamage>();
    }

    private void FixedUpdate()
    {
        if (takedamage.IsDeath)
        {
            animator.Play("death");
            return;
        }
        if (enemyManager.IsTakedamage)
        {
            animator.Play("hit_1");
        }
    }
    private void Update()
    {
        if(takedamage.IsDeath)
        {
            animator.Play("death");
            return;
        }
       else if (enemyManager.DistanceMagnitude <= 15 && !enemyManager.Isattacking && !enemyManager.IsTakedamage&& !enemyManager.IsUntilSkill&& !(enemyManager.y>5)  || enemyManager.IsfollowCowboy&&!enemyManager.Isattacking && !enemyManager.IsTakedamage && !enemyManager.IsUntilSkill&&!(enemyManager.y > 5))
        {
            animator.Play("run");
        }
       else if (/*enemyManager.DistanceMagnitude > 15 &&*/ !enemyManager.Isattacking && !enemyManager.IsTakedamage && !enemyManager.IsfollowCowboy && !enemyManager.IsUntilSkill)
        {
            animator.Play("walk");
        }
        else if (/*enemyManager.DistanceMagnitude < 5.7*/enemyManager.Isattacking && !enemyManager.IsTakedamage && !enemyManager.IsUntilSkill)
        {
            Debug.Log("Skill");
            animator.Play("skill_1");
        }
       else if(enemyManager.IsUntilSkill && !enemyManager.Isattacking)
        {
            animator.Play("evade_1");
        }
    }

}
