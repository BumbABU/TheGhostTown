using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlip : MonoBehaviour
{
    private BossFollow bossFollow;
    private SpawnEnemy spawnEnemy;
    private BossAttack bossAttack;
    [SerializeField]
    private Transform cowBoy;
    private float originalPosition;
    private float currentXPosition;

    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        bossFollow = GetComponent<BossFollow>();
        bossAttack = GetComponent<BossAttack>();
    }

    private void Start()
    {
        originalPosition = transform.position.x;
    }

    private void Update()
    {
        Flip();
    }
    private void Flip()
    {
        if (spawnEnemy.IsSpawn || bossFollow.IsFollowing || bossAttack.IsAttack)
        {
            if (cowBoy.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            currentXPosition = transform.position.x;
            if (currentXPosition < originalPosition)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            if (currentXPosition > originalPosition)
            {
                transform.localScale = new Vector3(-1, 1, 1); ;
            }
            originalPosition = currentXPosition;
        }
    }
}
