using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoss : MonoBehaviour
{
    private SpawnEnemy spawnEnemy;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(spawnEnemy.IsSpawn)
        {
            animator.Play("Cast");
        }
        else
        {
            animator.Rebind();
        }
    }
}
