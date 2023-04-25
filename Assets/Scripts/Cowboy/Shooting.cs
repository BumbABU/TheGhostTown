using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CowboyStatus cowboyStatus;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform shootingPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int currentBullet = 0;
    public int CurrentBullet { get { return currentBullet; } }
    [SerializeField]
    private int maxBullet =5;
    [SerializeField]
    private float reloadTime;

    private float timeDelta;
    [SerializeField]
    private float timePerOneshot;
    private bool canFire = true;
    private bool isReloading;
    private bool isShooting;
    public bool IsShooting { get { return isShooting; } }
    
    private void Awake()
    {
        cowboyStatus = GetComponent<CowboyStatus>();
       // animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentBullet = maxBullet;
        
    }

    private void Update()
    {

        if (currentBullet <= 0 && !isReloading)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && canFire && cowboyStatus.changeGun && !isReloading)
        {
            Shoot();
            
        }

        DelayShoot();
        if (!cowboyStatus.IsShooting)
        {
            animator.Rebind();
        }
        if (cowboyStatus.IsShooting)
        {
            animator.SetTrigger("shootPoint");
        }

    }
    private void DelayShoot()
    {
        this.timeDelta += Time.deltaTime;
        if (timeDelta < timePerOneshot)
        {
            return; 
        }
       
        timeDelta = 0;
        canFire = true;
        
    }

    private void Shoot()
    {
        GameObject bulletprefab = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        //bulletprefab.GetComponent<Bullet>().IsRight = transform.localScale == Vector3.one ? true : false;
        if (transform.localScale == Vector3.one)
        {
            bulletprefab.GetComponent<Bullet>().IsRight = true;
        }
        else
        {
            bulletprefab.GetComponent<Bullet>().IsRight = false;
        }

        bulletprefab.SetActive(true);
       /* bulletprefab.GetComponent<Rigidbody2D>().AddForce(transform.localScale == Vector3.one ? transform.right : -transform.right * bulletRate);*/
        canFire = false;
        currentBullet--;
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        isReloading = true;
        animator.Rebind();
        yield return new WaitForSeconds(reloadTime);
        currentBullet = maxBullet;
        isReloading = false;
        
    }

}
