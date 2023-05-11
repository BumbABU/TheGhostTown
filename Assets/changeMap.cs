using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeMap : MonoBehaviour
{
    [SerializeField]
    private listEnemy list;
    private bool levelComplete = false;
    private float x;
    private float y;
    private void Awake()
    {
        x = transform.position.x;
        y = transform.position.y;
        transform.position = new Vector3(x, y, -500);
    }
    private void Update()
    {
        if(list.lEnemys.Count <= 20)
        {
            transform.position = new Vector3(x, y, -1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cowboy") && !this.levelComplete)
        {


            this.levelComplete = true;
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("win");
            }

            Invoke("CompleteLevel", 2f);

        }
    }

    private void CompleteLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
