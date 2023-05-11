
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private float delayTimeSpawn;
    private float timerSpawn;
    [SerializeField]
    private List<GameObject> listItem;
    [SerializeField]
    private Transform spawnpointItem;
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        timerSpawn += Time.deltaTime;
        if (timerSpawn < delayTimeSpawn) return;
        timerSpawn = 0;
        int randomIndex = Random.Range(0, listItem.Count);
        GameObject enemyPrefab = Instantiate(listItem[randomIndex], spawnpointItem.position, Quaternion.identity);
        enemyPrefab.SetActive(true);

    }
}
