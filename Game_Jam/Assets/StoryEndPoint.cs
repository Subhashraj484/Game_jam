using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
             if(count == 3)
            {
                SceneManager.LoadScene("LVL1");
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
