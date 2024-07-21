using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContollsUI : MonoBehaviour
{
    private void Start() {
        StoryManager.Instance.ShowControlls += ShowControlls;
        gameObject.SetActive(false);
    }

    private void Update() {
        
        if(InputManager.Instance.Horizontal != 0)
        {
            gameObject.SetActive(false);

        }
    }

    private void ShowControlls()
    {
        gameObject.SetActive(true);
    }

}
