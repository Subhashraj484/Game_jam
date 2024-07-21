using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingGate : MonoBehaviour, ISwitchInteractable
{
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    private float currentSpeed;
    private Tween currentTween;

    [SerializeField] private Vector3 offsetTarget;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float increasedSpeed = 20f;

    private void Start() {
        initialPosition = transform.position;
        finalPosition = initialPosition + offsetTarget;
        currentSpeed = speed;
        StartMoving(currentSpeed);
    }

    private void StartMoving(float speed) {
        if (currentTween != null) {
            currentTween.Kill();
        }

        Vector3 targetPosition = (transform.position == initialPosition) ? finalPosition : initialPosition;
        float remainingDistance = (targetPosition - transform.position).magnitude;
        float duration = remainingDistance / speed;

        currentTween = transform.DOMove(targetPosition, duration)
            .OnComplete(() => StartMoving(currentSpeed))
            .SetEase(Ease.Linear);
    }

    public void Interact() {
        currentSpeed = (currentSpeed == speed) ? increasedSpeed : speed;
        

        StartMoving(currentSpeed);
    }

    public void Kill() {
        if (currentTween != null) {
            currentTween.Kill();
        }
    }
}
