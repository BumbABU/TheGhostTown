using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBreathing : MonoBehaviour
{
    [SerializeField]
    private GameObject firePrefab;
    [SerializeField]
    private Transform firePrefabPoint;

    private void Update()
    {
        BreathingFire();
    }
    private void BreathingFire ()
    {
        GameObject fireprefab = Instantiate(firePrefab, firePrefabPoint.position, transform.rotation);
    }
}
