using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
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
      if(spawnEnemy.IsSpawn)
        {
            animator.Play("spell1");
        }  
      else
        {
            animator.Rebind();
        }
    }
}
