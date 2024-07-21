using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onepressureswitch : MonoBehaviour
{
    [SerializeField] List<Transform> clinets;

    public void Interact()
    {
        foreach(Transform client in clinets)
        {
            if(client == null) continue;
            client.GetComponent<ISwitchInteractable>().Interact();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.TryGetComponent<IPreassueSwitchClient>(out IPreassueSwitchClient component))
        {
            
            Interact();
        }
    }

    /*private void OnTriggerExit2D(Collider2D other) {
        
        if(other.TryGetComponent<IPreassueSwitchClient>(out IPreassueSwitchClient component))
        {

            Interact();
        }

    }*/
}

