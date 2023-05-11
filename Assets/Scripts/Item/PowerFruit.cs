using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFruit : MonoBehaviour
{
    [SerializeField]
    private Shooting cowboy;
    [SerializeField]
    private int increasedDamage;
    private int defaultDamage;
    [SerializeField]
    private float timetoIncreasedDamage;
    private bool isCheck = false;
    private void Awake()
    {
        defaultDamage = cowboy.DamageBullet;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy") && !isCheck)
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("collect");
            }
            isCheck = true;
            StartCoroutine(IncreaseDamageBullet());
            gameObject.SetActive(false);
        }
    }

    private IEnumerator IncreaseDamageBullet ()
    {
        cowboy.DamageBullet += increasedDamage;
        yield return new WaitForSeconds(timetoIncreasedDamage);
        cowboy.DamageBullet = defaultDamage;
    }
}
