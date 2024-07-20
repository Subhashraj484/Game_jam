
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour , IInteractable
{
    [SerializeField] List<Transform> clinets;

    public void Interact(Player player)
    {
        foreach(Transform client in clinets)
        {
            client.GetComponent<ISwitchInteractable>().Interact();
        }
    }

    
}
