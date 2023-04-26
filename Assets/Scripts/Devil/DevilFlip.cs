using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilFlip : MonoBehaviour
{
    //private DevilOriginalPos devilOriginalPos;
    private float originalPos;
    private float currentPos;
    [SerializeField]
    private CowboyStatus cowboy;
    private DevilFollow devilFollow;

    private void Awake()
    {
       originalPos = transform.position.x;
        devilFollow = GetComponent<DevilFollow>();
    }

    private void Update()
    {
        if(!devilFollow.IsFollowing)
        {
            FlipOriginalPos();
            return;
        }
        FLiptoCowboy();
    }
    private void FlipOriginalPos()
    {
        currentPos = transform.position.x;
        if(currentPos > originalPos)
        {
            transform.localScale = new Vector3 ( 0.01f, 0.01f, 0.01f );
        }
        else
        {
            transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
        originalPos = currentPos;
    } 

    private void FLiptoCowboy()
    {
        if (cowboy == null) return;
        if(cowboy.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        else if (cowboy.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-0.01f, 0.01f, 0.01f);
        }
    }
}
