using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clouds : MonoBehaviour
{
    public float speed = 1.0f;
    public float resetPosition = -10.0f; 
    public float startPosition = 10.0f; 

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform component not found!");
        }
    }

    void Update()
    {
        if (rectTransform != null)
        {

            rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            // Debug.Log("Cloud position: " + rectTransform.anchoredPosition);

            if (rectTransform.anchoredPosition.x < resetPosition)
            {
                Vector2 newPosition = rectTransform.anchoredPosition;
                newPosition.x = startPosition;
                rectTransform.anchoredPosition = newPosition;
                // Debug.Log("Cloud reset to: " + rectTransform.anchoredPosition);
            }
        }
    }
}
