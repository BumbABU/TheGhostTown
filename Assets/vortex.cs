using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vortex : MonoBehaviour
{
    private void Update()
    {
        Invoke("Destroy", 1f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
