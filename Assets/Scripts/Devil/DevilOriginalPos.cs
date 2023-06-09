using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilOriginalPos : MonoBehaviour
{
    private DevilFollow devilFollow;
    [SerializeField]
    private Vector2 originalPos;
    public Vector2 OriginalPos { get { return originalPos; } }
    [SerializeField]
    private float speed;

    private void Awake()
    {
        originalPos = transform.position;
        devilFollow = GetComponent<DevilFollow>();
    }

    private void Update()
    {
        if (devilFollow.IsFollowing) return;
        this.Comeback();
    }
    private void Comeback()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
    }
}
