using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntillSkill : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField]
    private GameObject[] untilwayPoints;
    private int untilcurrentWaypoint = 0;
    private Rigidbody2D rb;
    private float originalRigidbodyScale;
    [SerializeField]
    private float untiRigidbodyScale;
    public float UntillSkillScale { get { return untiRigidbodyScale; } set {  untiRigidbodyScale = value; } }
    private void Awake()
    {
        
        enemyManager = GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Start()
    {
        originalRigidbodyScale = rb.gravityScale;
    }
    private void EnemysMoveuntilwaypoint()
    {
        if (Vector2.Distance(untilwayPoints[untilcurrentWaypoint].transform.position, transform.position) < 1f)
        {

            untilcurrentWaypoint++;
            if (untilcurrentWaypoint >= untilwayPoints.Length)
            {
                untilcurrentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, untilwayPoints[untilcurrentWaypoint].transform.position, enemyManager.Speed * Time.deltaTime);

    }

    public IEnumerator _untilSkill()
    {

        //Debug.Log("roadmap1");
        rb.gravityScale = untiRigidbodyScale;
        enemyManager.IsUntilSkill= true;
        enemyManager.Speed = 15;
        EnemysMoveuntilwaypoint();
        yield return new WaitForSeconds(5f);  
        rb.gravityScale = originalRigidbodyScale;
        enemyManager.CanUntilSkill = false;
        enemyManager.IsUntilSkill = false;
        yield return new WaitForSeconds(20);
        enemyManager.CanUntilSkill = true;
    }
}
