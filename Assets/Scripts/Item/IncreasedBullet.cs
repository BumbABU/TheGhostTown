using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedBullet : MonoBehaviour
{
    [SerializeField]
    private int bullettoIncreased;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy"))
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("collect");
            }
            Shooting cowboy = collision.GetComponent<Shooting>();
            cowboy.CurrentBullet += bullettoIncreased;
            gameObject.SetActive(false);
        }
    }
}
