using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Xml.Schema;
using Unity.Mathematics;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    public UntillSkill untillSkill;
    public Follow follow;
    public DamagetoCowboy damagetoCowboy;
    public MoveWaypoints moveWaypoints;
    public Takedamage TakeDamge;
    [SerializeField]
    private CowboyStatus cowboyst;
    [SerializeField]
    private float defaultDamage =10;
    public float DefaultDamage { get { return defaultDamage; } }
    [SerializeField]
    private float skillDamage = 0.05f;
    public float SkillDamage { get { return skillDamage; } }
    [SerializeField]
    private Transform cowBoy;
    [SerializeField]
    private float speed = 5;
    public float Speed { get { return speed; } set { speed = value; } }    
    
    private Vector3 distance;
    public Vector3 Distance { get { return distance; } }
    private float distanceMagnitude;
    public float DistanceMagnitude { get { return distanceMagnitude; } }

/// </summary>
    private bool isattacking = false;
    public bool Isattacking { get { return isattacking; } set { isattacking = value; } }

    private bool isUntilSkill = false;
    public bool IsUntilSkill { get { return isUntilSkill; } set { isUntilSkill = value; } }

    private bool canUntilSkill = false;
    public bool CanUntilSkill { get { return canUntilSkill; } set { canUntilSkill = value; } }

    private bool isfollowCowboy = false;
    public bool IsfollowCowboy { get { return isfollowCowboy; } set { isfollowCowboy = value; } }
 
    private bool isTakedamage = false;
    public bool IsTakedamage { get { return isTakedamage; } set { isTakedamage= value; } }
    /// <summary>
    private float distanceY;
    public float  y;
/// </summary>
    private float originalPosition;
    private float currentXPosition;
    private void Awake()
    {
        follow = GetComponent<Follow>();
        untillSkill = GetComponent<UntillSkill>();
        damagetoCowboy = GetComponent <DamagetoCowboy>();
        moveWaypoints = GetComponent<MoveWaypoints>();
        TakeDamge = GetComponent<Takedamage>();

    }
    private void Start()
    {
        //canUntilSkill = true;
        Invoke("SetCanUntill", 2f);
        originalPosition = transform.position.x;
    }
    private void Update()
    {
        if (cowboyst.IsDeath)
        {
            isattacking = false;
            isUntilSkill = false;
            isfollowCowboy = false;
            return;
        }
        if(TakeDamge.IsDeath)
        {
            return;
        }
        distanceY = cowBoy.position.y - transform.position.y;
         y = Mathf.Abs(distanceY);
        distance = this.cowBoy.position - transform.position; //distance này trả về 1 điểm khắc từ điểm cowboy tới điểm transfrom;
        distanceMagnitude = distance.magnitude; //distance.magnitude hàm này giúp tính toán và trả lại độ dài từ cowboy tới transform; 
        FlipEnemy();
       
        if (distanceMagnitude <= 15 && !isattacking && !isUntilSkill && !(y > 5f) || isfollowCowboy && !isattacking && !isUntilSkill && !(y > 5f))
        {
            isfollowCowboy = true;
            follow.FollowCowboy();
        }
        else if ( y >6f)
        {
            isfollowCowboy=false;
        }


        if ( !isattacking && !isfollowCowboy && !isUntilSkill)
        {
            speed = 2;
            moveWaypoints.EnemysMovetowaypoint();
        }

        if (canUntilSkill && !isattacking && !isfollowCowboy)
        {
            untillSkill.StartCoroutine(untillSkill._untilSkill());
        }


    }

    private void FlipEnemy()
    {
        if (/*distance.magnitude <= 15 && !isUntilSkill ||*/ isfollowCowboy && !isUntilSkill)
        {
            if (cowBoy.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.02f, 0.02f, 0.02f);
            }
            else
            {
                transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            }
        }
        if ( !isfollowCowboy)
        {
            currentXPosition = transform.position.x;
            if (currentXPosition < originalPosition)
            {
                transform.localScale = new Vector3(-0.02f, 0.02f, 0.02f);

            }
            if (currentXPosition > originalPosition)
            {
                transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            }
            originalPosition = currentXPosition;
        }
    }

    private void SetCanUntill()
    {
        canUntilSkill = true;
    }
}
















