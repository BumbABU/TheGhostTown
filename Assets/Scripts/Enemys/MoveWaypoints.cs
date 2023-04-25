using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWaypoints : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wayPoints;
    private int currentWaypoint = 0;
    private EnemyManager enemyManager;
    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        //mummyTakeDamage = GetComponent<MumyTakeDamage>();
    }
    public void EnemysMovetowaypoint()
    {
        if (Vector2.Distance(wayPoints[currentWaypoint].transform.position, transform.position) < 1f)
        {

            currentWaypoint++;
            if (currentWaypoint >= wayPoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypoint].transform.position, enemyManager.Speed * Time.deltaTime);
    }
}
