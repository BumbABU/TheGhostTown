using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoss : MonoBehaviour
{
    private BossFollow bossFollow;
    private BossAttack bossAttack;
    private BossTakeDamage bossTakeDamage;
    private SpawnEnemy spawnEnemy;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        bossTakeDamage = GetComponent<BossTakeDamage>();
        spawnEnemy = GetComponent<SpawnEnemy>();
        animator = GetComponent<Animator>();
        bossAttack = GetComponent<BossAttack>();
        bossFollow = GetComponent<BossFollow>();
    }

    private void Update()
    {  if(bossTakeDamage.IsDeath)
        {
            animator.Play("death");
            return;
        }
        else if (bossAttack.IsAttack)
        {
            animator.Play("attack");
        }
        else if (bossFollow.IsFollowing && !bossAttack.IsAttack)
        {
            animator.Play("run");
        } 
        else if(spawnEnemy.IsSpawn && !bossAttack.IsAttack && !bossFollow.IsFollowing)
        {
            animator.Play("cast");
            Debug.Log("playCast");
        }
        else  
        {
            animator.Play("walk");
        }
    }
}
