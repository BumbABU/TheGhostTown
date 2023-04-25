using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummymoveWaypoint : MonoBehaviour
{
    private MummyFollow mummyFollow;
    private MummyAttack mummyAttack;
    [SerializeField]
    private GameObject[] wayPoints;
    private int currentWaypoint = 0;
    [SerializeField]
    private float walkSpeed =2;
    private MumyTakeDamage mummyTakeDamage;
    private void Awake()
    {
        mummyFollow = GetComponent<MummyFollow>();
        mummyTakeDamage = GetComponent<MumyTakeDamage>();
        mummyAttack = GetComponent<MummyAttack>();
    }
    private void Update()
    {
        if (mummyTakeDamage.IsDeath) return;
        if(mummyAttack.IsAttack) return;
        if(!mummyFollow.IsFollowing)
        {
            EnemysMovetowaypoint();
        }
    }
    public void EnemysMovetowaypoint()
    {
        if (Vector2.Distance(wayPoints[currentWaypoint].transform.position, transform.position) < 1.5f)
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
