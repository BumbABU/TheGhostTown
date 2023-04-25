using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumyFlip : MonoBehaviour
{
    private MummyFollow mummyFollow;
    [SerializeField]
    private Transform cowBoy;
    private float originalPosition;
    private float currentXPosition;

    private void Awake()
    {
        mummyFollow = GetComponent<MummyFollow>();
    }

    private void Start()
    {
        originalPosition = transform.position.x;
    }

    private void Update()
    {
        if (mummyFollow != null)
        {
            Flip();
        }
    }
    private void Flip()
    {
        if (mummyFollow.IsFollowing )
        {
            if (cowBoy.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if (!mummyFollow.IsFollowing)
        {
            currentXPosition = transform.position.x;
            if (currentXPosition < originalPosition)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
            if (currentXPosition > originalPosition)
            {
                transform.localScale = new Vector3(1, 1, 1); ;
            }
            originalPosition = currentXPosition;
        }
    }
}
