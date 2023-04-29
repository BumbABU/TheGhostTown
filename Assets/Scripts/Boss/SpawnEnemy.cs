using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private HealthEnemy health;
    [SerializeField]
    private List<GameObject> enemyprefabList;
    [SerializeField]
    private List<GameObject> enemyList;
    [SerializeField]
    private Transform spawnPoint;
    private float timerSpawn;
    [SerializeField]
    private float delayTimeSpawn;
    private bool CanSpawn = false;
    private int currentEnemy;
    private int maxEnemy;
    // private float health;
    private bool isSpawn;
    public bool IsSpawn { get { return isSpawn; } }
    private void Awake()
    {
        // health = GetComponent<HealthEnemy>();
        currentEnemy = 5;

    }
    private void Update()
    {
        RemoveDeathEnemy();


        if (currentEnemy == 5)
        {
            if (enemyprefabList.Count >= 5)
            {
                isSpawn = false;
                currentEnemy = 0;
                return;
            }

            
            Spawn();
        }


    }
    private void Spawn ()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn < delayTimeSpawn) return;
        timerSpawn = 0;
        isSpawn = true;
        int randomIndex = Random.Range(0, enemyList.Count);
        GameObject enemyPrefab = Instantiate(enemyList[randomIndex], spawnPoint.position, Quaternion.identity);
        enemyPrefab.SetActive(true);
        
        enemyprefabList.Add(enemyPrefab);
        CanSpawn = false;
        
    }



    private void RemoveDeathEnemy()
    {
        for (int i = 0; i < enemyprefabList.Count; i++)
        {
            if (enemyprefabList[i].GetComponent<HealthEnemy>().Health <= 0)
            {
                enemyprefabList.RemoveAt(i);
                currentEnemy++;
            }

        }
    }
}
