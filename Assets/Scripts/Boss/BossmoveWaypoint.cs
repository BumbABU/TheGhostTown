using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossmoveWaypoint : MonoBehaviour
{
    private BossFollow bossFollow;
    [SerializeField]
    private SpawnEnemy spawnEnemy;
    [SerializeField]
    private GameObject[] wayPoints;
    private int currentWaypoint = 0;
    [SerializeField]
    private float walkSpeed = 2;
    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        bossFollow = GetComponent<BossFollow>();
    }
    private void Update()
    {
        if (spawnEnemy.IsSpawn) return;
        if(bossFollow.IsFollowing) return;

        EnemysMovetowaypoint();
    }
    public void EnemysMovetowaypoint()
    {
        if (Vector2.Distance(wayPoints[currentWaypoint].transform.position, transform.position) <3f)
        {

            currentWaypoint++;
            if (currentWaypoint >= wayPoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypoint].transform.position, walkSpeed * Time.deltaTime);
    }
}
