using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttack : MonoBehaviour
{
    private MumyTakeDamage mummyTakeDamage;
    [SerializeField]
    private CowboyStatus cowboyStatus;
    private bool isAttack = false;
    public bool IsAttack { get { return isAttack; } }
    private float timertakeDamage = 0;
    [SerializeField]
    private float delayTakedamage = 0.005f;
    [SerializeField]
    private float mummyDamage = 5f;

    private void Awake()
    {
        mummyTakeDamage = GetComponent<MumyTakeDamage>();
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
            if (!cowboyStatus.IsDashingCut && !mummyTakeDamage.IsDeath)
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
        cowboyStatus.cowboyTakedamage(mummyDamage);

    }
}
