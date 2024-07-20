using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
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
                other.transform.GetComponent<Player>().EnableJump();
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