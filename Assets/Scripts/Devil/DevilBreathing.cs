using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBreathing : MonoBehaviour
{
    [SerializeField] 
    private List<GameObject> listfirePrefab;
    [SerializeField]
    private GameObject firePrefab;
    [SerializeField]
    private Transform firePrefabPoint;
    private bool isBreath;
    public bool IsBreath { get { return isBreath; } }
    private float timerBreath = 0;
    [SerializeField]
    private float delayTimeBreath;
    public float DelayTimeBreath { get { return delayTimeBreath; } }

    private void Update()
    {
        // DelayBreath();

        Debug.Log(listfirePrefab.Count);
        if(listfirePrefab.Count >= 3)
        {
            Invoke("RemoveListFire", 3f);
            return;
            
        }
        BreathingFire();
    }
    private void BreathingFire ()
    {
        //if (listfirePrefab.Count >= 3) return;
        timerBreath += Time.deltaTime;
        if (timerBreath < delayTimeBreath) return;
        timerBreath = 0;
        GameObject fireprefab = Instantiate(firePrefab, firePrefabPoint.position, transform.rotation);
        fireprefab.SetActive(true);
        this.listfirePrefab.Add(fireprefab);
    }

    private void RemoveListFire()
    {
        listfirePrefab.RemoveAll(obj => obj == null);
    }

}
