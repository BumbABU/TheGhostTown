using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAnimation : MonoBehaviour
{
    private MummyAttack mummyAttack;
    private MummyFollow mummyFollow;
    [SerializeField]
    private Animator animator;
    private MumyTakeDamage mummyTakeDamage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mummyFollow = GetComponent<MummyFollow>();
        mummyTakeDamage = GetComponent<MumyTakeDamage>();
        mummyAttack = GetComponent<MummyAttack>();
    }

    private void Update()
    {
        if(mummyTakeDamage.IsDeath)
        {
            animator.Play("mummy_Death");
            return;
        }
        if(mummyAttack.IsAttack)
        {
            animator.Play("mummy_Attack");
            return;
        }
        if(mummyAttack.IsAttack)
        {
            return;
        }
        if(mummyTakeDamage.IsTakeDamage)
        {
            animator.Play("mummy_Hurt");
        }
       if(!mummyFollow.IsFollowing&&!mummyTakeDamage.IsTakeDamage)
        {

            animator.Play("mummy_Walk");
        }
       else if (mummyFollow.IsFollowing&&!mummyTakeDamage.IsTakeDamage)
        {
            animator.Play("mummy_Run");
        }
    }
}
