using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEndPoint : MonoBehaviour
{
    public static StoryEndPoint Instance {get ; private set ;}

    private void Awake() {
        Instance = this;
    }

    public event Action OnFirst;
    public event Action OnSecond;
    [SerializeField] Transform startPoint;
    int count =0;
    Collider2D player;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player"))
        {
            player = other;

            count++;

                Debug.Log("hunsffh");
            if(count == 1)
            {
                // other.transform.GetComponent<Player>().EnableJump();
                OnFirst?.Invoke();
            }

            if(count == 2)
            {
                OnSecond?.Invoke();
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
