using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    [SerializeField]
    private BossTakeDamage boss;
    [SerializeField]
    private SpawnEnemy spawnEnemy;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (boss.IsDeath) return;

      if(spawnEnemy.IsSpawn)
        {
            animator.Play("Spell");
        }  
      else
        {
            animator.Rebind();
        }
    }
}
