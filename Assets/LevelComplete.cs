using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private bool levelComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cowboy") && !this.levelComplete)
        {

          
            this.levelComplete = true;

            Invoke("CompleteLevel", 2f);

        }
    }

    private void CompleteLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
