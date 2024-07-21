using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL4EndPoint : MonoBehaviour
{
   [SerializeField] Transform startPoint;
    int count =0;
    Collider2D player;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player"))
        {
            player = other;
            count++;
            if(count == 3*2)
            {
                SceneManager.LoadScene("LVL3");
            }

            StartCoroutine(Delay());

        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = startPoint.position;

    }
}
