using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField]
    private Transform cowBoy;
    private Vector2 distance;
    public Vector2 DisTance { get { return distance; } }
    private void Update()
    {
        distance = this.cowBoy.position - transform.position;
    }
}