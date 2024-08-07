using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DashEndPoint : MonoBehaviour
{
    [SerializeField] Player playerS;

    private void Start() {
        playerS.EnableJump();
    }
    [SerializeField] Transform startPoint;
    int count =0;
    Collider2D player;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player"))
        {
            player = other;
            count++;

            if(count == 1)
            {
                other.transform.GetComponent<Player>().EnableDash();
            }
             if(count == 3)
            {
                SceneManager.LoadScene("LVL4");
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
