using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBreathing : MonoBehaviour
{
    private DevilAttack devilAttack;
    private Distance distance;
    [SerializeField] 
    private List<GameObject> listfirePrefab;
    public List<GameObject> ListfirePrefab { get { return listfirePrefab; } }
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
    [SerializeField]
    private float distanceBreathmin;
    [SerializeField]
    private float distanceBreathmax;
    [SerializeField]
    private int coutfire1turn =3;
    public int Coutfire1turn { get {  return coutfire1turn; } }

    private void Awake()
    {
        distance = GetComponent<Distance>();
        devilAttack = GetComponent<DevilAttack>();
    }
    private void Update()
    {
        // DelayBreath();

        if(listfirePrefab.Count >= coutfire1turn)
        {
            Invoke("RemoveListFire", 3f);
            return;
            
        }
        if(distance.DisTance.magnitude > distanceBreathmin && distance.DisTance.magnitude < distanceBreathmax && !devilAttack.IsAttack )
        {
            isBreath = true;
            BreathingFire();
        }
        else
        {
            isBreath= false;
        }
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
