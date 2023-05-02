using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectedFruit : MonoBehaviour
{
    private bool ischeck = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy") && !ischeck)
        {
            ischeck = false;
            CowboyStatus cowboy = collision.GetComponent<CowboyStatus>();
            cowboy.Reborn = transform;
            gameObject.SetActive(false);
        }
    }
}
