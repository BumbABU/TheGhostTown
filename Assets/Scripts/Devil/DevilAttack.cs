using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilAttack : MonoBehaviour
{
    private DevilTakeDamage devilTakeDamage;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private bool isAttack = false;
    public bool IsAttack { get { return isAttack; } }
    private float timertakeDamage = 0;
    [SerializeField]
    private float delayTakedamage = 0.005f;
    [SerializeField]
    private float devilDamage = 5f;

    private void Awake()
    {
        devilTakeDamage = GetComponent<DevilTakeDamage>();
    }

    private void Update()
    {
        if (isAttack)
        {
            AttackCowboy();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Cowboy"))
        {
            if (!cowboyStatus.IsDashingCut && !devilTakeDamage.IsDeath)
            {
                isAttack = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cowboy"))
        {
            isAttack = false;
        }
    }

    private void AttackCowboy()
    {
        timertakeDamage += Time.deltaTime;
        if (timertakeDamage < delayTakedamage) return;
        timertakeDamage = 0;
        cowboyStatus.cowboyTakedamage(devilDamage);

    }
}
