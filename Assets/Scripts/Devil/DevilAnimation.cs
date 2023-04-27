using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilAnimation : MonoBehaviour
{
    private DevilTakeDamage devilTakeDamage;
    private DevilAttack devilAttack;
    private DevilBreathing devilBreathing;
    private DevilFollow devilFollow;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        devilAttack = GetComponent<DevilAttack>();
        devilBreathing = GetComponent<DevilBreathing>();
        devilFollow = GetComponent<DevilFollow>();
        devilTakeDamage = GetComponent<DevilTakeDamage>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(devilTakeDamage.IsDeath)
        {
            animator.Play("death");
            return;
        }
        if(devilTakeDamage.IsTakeDamage)
        {
            animator.Play("hit_2");
        }
        if(devilFollow.IsFollowing && !devilBreathing.IsBreath && !devilAttack.IsAttack &&!devilTakeDamage.IsTakeDamage)
        {
            animator.Play("idle_1"); //run when follow
        }
        else if(devilBreathing.IsBreath && !devilAttack.IsAttack && !devilTakeDamage.IsTakeDamage)
        {
            if(devilBreathing.ListfirePrefab.Count >= devilBreathing.Coutfire1turn)
            {
                animator.Play("idle_1"); // play when fire delay
            }
            else
            {
                animator.Play("idle_2"); // play when breathing fire
            }

        }
        else if (devilAttack.IsAttack && !devilTakeDamage.IsTakeDamage)
        {
            animator.Play("skill_1");
        }
        else 
        {
            if (!devilTakeDamage.IsTakeDamage)
            {
                animator.Play("walk");
            }
        }
    }
}
