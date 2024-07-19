using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
public class InputManager : MonoBehaviour
{
    float horizontal ;
    public event EventHandler OnJump;

    public static InputManager Instance {get ; private set;}

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke(this , EventArgs.Empty);
        }
    }

    public float Horizontal => horizontal;
}
