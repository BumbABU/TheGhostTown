using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyAnimation : MonoBehaviour
{
    [SerializeField]
    private FireBreathing fireBreathing;
    [SerializeField]
    private EnemyManager enemyManager;
    private CowboyStatus cowboyStatus;
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } set { animator = value; } }
    [SerializeField]
    private RuntimeAnimatorController animator_Default;
    [SerializeField]
    private RuntimeAnimatorController animator_Gun;
    [SerializeField]
    private Rigidbody2D rb;
    private enum MovementState { Idle, Jumping, Falling, Runing }
    private MovementState movementState;

    private enum MovementwithGun { IdleAim, JumpingShot, FallingAim, RunningShot, IdleShot, FallingShot }
    private MovementwithGun movementwithGun;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animator_Default;
        cowboyStatus = GetComponent<CowboyStatus>();
    }

    private void Update()
    {
        if (cowboyStatus.IsDeath)
        {
            animator.Play("cowboy_Death");
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && cowboyStatus.IsCanDash && !cowboyStatus.changeGun)
        {
            StartCoroutine(DashCutAnimation());
        }
        if (cowboyStatus.IsTakeDamage)
        {
            animator.Play("cowboy_Hurt");
          
        }
      /*  if(!fireBreathing.IsstickCowboy)
        {
            Debug.Log("animationPlay");
            animator.Rebind();
        }*/
    }
    private void FixedUpdate()
    {
        if (cowboyStatus.IsDeath)
        {
            animator.Play("cowboy_Death");
            return;
        }
        if (!cowboyStatus.changeGun)
        {
            animator.runtimeAnimatorController = animator_Default;
            update_animation();
        }
        if (cowboyStatus.changeGun)
        {
            animator.runtimeAnimatorController = animator_Gun;
            gun_animation();
        }
       
    }
    private void update_animation()
    {
        if (cowboyStatus.Dirx > 0f)
        {
           // this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localScale = Vector3.one;
            movementState = MovementState.Runing;
        }
        else if (cowboyStatus.Dirx < 0f)
        {
            //this.transform.rotation = Quaternion.Euler(0, 180, 0);
            this.transform.localScale = new Vector3(-1, 1, 1);
            movementState = MovementState.Runing;
        }
        else
        {
            movementState = MovementState.Idle;
        }
        if (rb.velocity.y > 1.5f)
        {
            movementState = MovementState.Jumping;
        }
        else if (rb.velocity.y < -5f)
        {
            movementState = MovementState.Falling;
        }

        animator.SetInteger("State", (int)movementState);
    }

    private void gun_animation()
    {
        if (cowboyStatus.Dirx > 0f)
        {
            this.transform.localScale = Vector3.one;
            movementwithGun = MovementwithGun.RunningShot;
        }
        else if (cowboyStatus.Dirx < 0f)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            movementwithGun = MovementwithGun.RunningShot;
        }
        else
        {
            if (cowboyStatus.IsShooting)
            {
                movementwithGun = MovementwithGun.IdleShot;
            }
            else
            {
                movementwithGun = MovementwithGun.IdleAim;
            }
        }
        if (/*rb.velocity.y > 1.5f*/cowboyStatus.Rb.velocity.y>1.5f)
        {
            movementwithGun = MovementwithGun.JumpingShot;
        }
        else if (cowboyStatus.Rb.velocity.y < -5f)
        {
            if (cowboyStatus.IsShooting)
            {
                movementwithGun = MovementwithGun.FallingShot;
            }
            else
            {
                movementwithGun = MovementwithGun.FallingAim;
            }
        }

        animator.SetInteger("StateGun", (int)movementwithGun);
    }

    private IEnumerator DashCutAnimation()
    {
        animator.Play("cowboy_Dashingcut");  
        yield return new WaitForSeconds(cowboyStatus.DashingTime);
        animator.Rebind();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            animator.Rebind();
        }
        else if (collision.CompareTag("mummy"))
        {
            animator.Rebind();
        }
    }
}
