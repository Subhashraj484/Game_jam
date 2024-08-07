using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GainPushAbilityEndPoint : MonoBehaviour
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
                other.transform.GetComponent<Player>().EnablePushAbility();
            }
            if(count == 3)
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
