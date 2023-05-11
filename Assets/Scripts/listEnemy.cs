using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listEnemy : MonoBehaviour
{
    public List<GameObject> lEnemys;
    
    //private int coutDeathEnemys =0;

    private void Update()
    {
        CoutEnemyDeath();
        Debug.Log(lEnemys.Count);
    }
    private void CoutEnemyDeath()
    {
        for (int i = 0; i < lEnemys.Count; i++)
        {
            if (lEnemys[i].GetComponent<HealthEnemy>().Health <=0)
                
            {
                lEnemys.RemoveAt(i);
            }
        }
    }
}
