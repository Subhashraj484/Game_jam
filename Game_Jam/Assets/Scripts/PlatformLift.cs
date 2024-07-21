using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformLift : MonoBehaviour,ISwitchInteractable
{
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private bool isInteracted;
    private Tween currentTween;
    
    [SerializeField] private Vector3 offsetTarget;
    [SerializeField] private float speed = 5f;

    private void Start() {
        initialPosition = transform.position;
        finalPosition = initialPosition + offsetTarget;
    }

    public void Interact() {
        if (Vector3.Distance(transform.position,finalPosition)>0.1) return;
        isInteracted = !isInteracted;

        if (isInteracted) {
            currentTween = transform.DOMove(finalPosition, speed);
        } else {
            currentTween = transform.DOMove(initialPosition, speed);
        }
    }



    public void Kill()
    {
         if (currentTween != null) {
                currentTween.Kill();
            }
    }
}
