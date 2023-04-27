using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
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

    private void Update()
    {
        DelaySpawn();
        if(CanSpawn)
        {
            Spawn();
        }
    }
    private void Spawn ()
    {
        int randomIndex = Random.Range(0, enemyList.Count - 1);
        var enemyPrefab = Instantiate(enemyList[randomIndex], spawnPoint.position, Quaternion.identity);
        enemyPrefab.SetActive(true);
        enemyprefabList.Add(enemyPrefab);
        CanSpawn = false;
    }

    private void DelaySpawn()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn < delayTimeSpawn) return;
        timerSpawn = 0;
        CanSpawn = true;
    }
}
