using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class CowboyStatus : MonoBehaviour
{
    [SerializeField]
    private TrailRenderer trailRenderer;
    [SerializeField]
    private Shooting shoot;
    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private Transform reborn;
    public Transform Reborn { get { return reborn; } }
    private CowboyAnimation cowboyAnimation;
    [SerializeField]
    private float timedelayTakedamage = 1f;
    [SerializeField]
    private float cowBoyHealth = 100;
    [SerializeField]
    private float damageCut = 20;
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private float jumpHeight =15;
    [SerializeField]
    private float cowboy_speed = 10;
    [SerializeField]
    private float foreceEffectDash = -1;
    public float ForeceEffectDash { get { return foreceEffectDash; } set {  foreceEffectDash = value; } }
    [SerializeField]
    private float foreceEffectBullet = -5;
    public float ForeceEffectBullet { get {  return foreceEffectBullet; } set { foreceEffectBullet= value; } }
    [SerializeField]
    private Rigidbody2D rigidBody;
    public Rigidbody2D Rb { get { return rigidBody; } }
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private BoxCollider2D boxCollider2;
    public bool changeGun = false;
    private bool Default = true;
    private bool isCanDash = true;
    public bool IsCanDash { get { return isCanDash; } }
    private bool isDashingCut;
    public bool IsDashingCut { get { return isDashingCut; } }
    [SerializeField]
    private float dashingTime = 0.4f;
    public float DashingTime { get { return dashingTime; } }
    private float dashingCooldown = 1f;
    [SerializeField]
    private float dashingPower = 20f;

    private bool isTakeDamage = false;
    public bool IsTakeDamage { get { return isTakeDamage; } set { isTakeDamage = value; } }

    [SerializeField]
    private float dirx;
    public float Dirx { get { return dirx; } }

    private bool isShooting;
    public bool IsShooting { get { return isShooting; } set { isShooting = value; } }

    private bool isDeath = false;
    public bool IsDeath { get { return isDeath; } }
    
    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        cowboyAnimation = GetComponent<CowboyAnimation>();
        shoot = GetComponent<Shooting>();
        boxCollider.isTrigger = false;
        boxCollider2.isTrigger = true;
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        trailRenderer.emitting = false;
    }
    private void FixedUpdate()
    {
        if (isDashingCut)
        {
            return;
        }
        cowboy_moving();
    }

    private void Update()
    {
       //  Debug.Log(cowBoyHealth);
       // Debug.Log("cowboyTakeDamge" + isTakeDamage);
        if (isTakeDamage)
        {
            cowboy_speed = 0;
        }
        else
        {
            cowboy_speed = 10;
        }

        if (isDashingCut)
        {
            return;
        }
        this.dirx = Input.GetAxisRaw("Horizontal");
        this.jump();
        if (cowBoyHealth <= 0)
        {
            isDeath = true;
            cowboyDeath();
        }
        if (Input.GetMouseButtonDown(0) && changeGun && (shoot.CurrentBullet>0))
        {
            isShooting = true;
            Debug.Log("Shoot");
        }
        if (Input.GetMouseButtonUp(0) && changeGun)
        {
            isShooting = false;
            Debug.Log("NotShoot");

        }
        if (Input.GetMouseButtonDown(1))
        {
            changeGun = !changeGun;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isCanDash && !changeGun)
        {
            StartCoroutine(DashCut());
        }
        boxCollider2.isTrigger = true;
        if (!isDashingCut)
        {
            boxCollider.isTrigger = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Restart();
        }
    }
    private IEnumerator DashCut()
    {
        /*  animator.Play("cowboy_Dashingcut");*/
        isCanDash = false;
        isDashingCut = true;
        trailRenderer.emitting = true;
        float original_gravityScale = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
        rigidBody.velocity = new Vector2(dirx * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidBody.gravityScale = original_gravityScale;
        isDashingCut = false;
        //animator.Rebind();
        yield return new WaitForSeconds(dashingCooldown);
        isCanDash = true;

    }

    public void cowboyTakedamage(float damage)
    {

        cowBoyHealth -= damage;
        isTakeDamage = true;
    }
    private void cowboy_moving()
    {
        if (this.rigidBody.bodyType != RigidbodyType2D.Static)
        {
            rigidBody.velocity = new Vector2(dirx * cowboy_speed, rigidBody.velocity.y);
        }
    }

    private void jump()
    {
        if (this.IsGround() && Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, this.jumpHeight);
        }
    }
    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Takedamage enemy = collision.GetComponent<Takedamage>();
            EnemyManager enemy1 = collision.GetComponent<EnemyManager>();


            if (enemy != null && isDashingCut && !enemy1.IsUntilSkill)
            {
                boxCollider.isTrigger = true;
                enemy.TakeDamage(damageCut);

            }
        }
        else if (collision.CompareTag("mummy"))
        {
            MumyTakeDamage mummy = collision.GetComponent<MumyTakeDamage>();
            if(mummy!= null && isDashingCut)
            {
                boxCollider.isTrigger = true;
                mummy.TakeDamage(damageCut);
            } 
        }
        else if (collision.CompareTag("Devil"))
        {
            DevilTakeDamage devil = collision.GetComponent<DevilTakeDamage>();
            if (devil != null && isDashingCut)
            {
                boxCollider.isTrigger = true;
                devil.TakeDamage(damageCut);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isTakeDamage = false;
        }
        else if (collision.CompareTag("mummy"))
        {
            isTakeDamage = false;
        }
        else if (collision.CompareTag("Devil"))
        {
            isTakeDamage = false;
        }
        else if (collision.CompareTag("boss"))
        {
            isTakeDamage = false;
        }
    }

    private void cowboyDeath()
    {
        rigidBody.bodyType = RigidbodyType2D.Static;
        Invoke("Restart", 1f);
    }

    private void Restart()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        this.transform.position = reborn.position;
        isDeath = false;
        cowboyAnimation.Animator.Rebind();
        cowBoyHealth = 100;

    }
}

