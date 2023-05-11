using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField]
    private CowboyStatus cowboy;
    private bool isTrap = false;
    private float currentTime =0;
    private float timeToDedelay =1;
    [SerializeField] 
    private Animator animator;
    private void Update()
    {
        if(isTrap)
        {
            DamageToCowboy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy"))
        {
            isTrap = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {
            isTrap = false;
            animator.Rebind();
        }
    }

    private void DamageToCowboy()
    {
        currentTime += Time.deltaTime;
        if (currentTime < timeToDedelay) return;
        currentTime = 0;
        cowboy.cowboyTakedamage(2);
    }

}
