using System;
using UnityEngine;

public class GravityBoxAudio : MonoBehaviour
{
    [SerializeField] GravityBox gravityBox;

    private void Start() {
        gravityBox.OnInteract += OnInteract;
    }

    private void OnInteract(object sender, GravityBox.OnInteractEventArgs e)
    {
        if(e.boxType == GravityBox.BoxType.Destroy)
        {
            
            SFXManager.Instance.PlayBreakSound(transform.position );
        }
    }
}
