using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResurrectedFruit : MonoBehaviour
{
    private bool ischeck = false;
    [SerializeField]
    private bool isCanResuccrect = false;
    public bool IsCanResuccrect { get { return isCanResuccrect; } set { isCanResuccrect = value; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cowboy") && !ischeck)
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("collect");
            }
            ischeck = false;
            CowboyStatus cowboy = collision.GetComponent<CowboyStatus>();
            cowboy.Reborn = transform;
            gameObject.SetActive(false);
            isCanResuccrect = true;
            /*Invoke("ChangeIsCanResuccrect", 2f);*/
        }
    }

}
