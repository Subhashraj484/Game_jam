using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftKiller : MonoBehaviour
{
    [SerializeField] Lift lift;

    private void OnTriggerEnter2D(Collider2D other) {

    if (other.transform.TryGetComponent<GravityBox>(out GravityBox component) || other.transform.TryGetComponent<PullBox>(out PullBox component2)) {
            
            Debug.Log("Collision detected with ShadowBox");

            lift.Kill();
           
        }
    }
}
