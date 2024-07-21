
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    float horizontal ;
    public event EventHandler OnJump;
    public event EventHandler OnInteract;


    [SerializeField] bool TriggerOnFirstMove;

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

        
        if(Input.GetKeyDown(KeyCode.F))
        {
            OnInteract?.Invoke(this , EventArgs.Empty);
        }
    }



    public float Horizontal => horizontal;
}
