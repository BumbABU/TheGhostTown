using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private bool isCheck = false;
    private float maxHealth;
    private void Awake()
    {
        maxHealth = cowboyStatus.CowboyHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy") && !isCheck)
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("collect");
            }
            isCheck = true;
            CowboyStatus cowboy = collision.GetComponent<CowboyStatus>();
            cowboy.CowboyHealth += 50;
            if (cowboy.CowboyHealth > maxHealth)
            {
                cowboy.CowboyHealth = maxHealth;
            }
            gameObject.SetActive(false);
        }
    }
}
