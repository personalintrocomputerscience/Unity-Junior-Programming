using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    // Changed leftLimit to -30 if it represents the left side of the screen
    private float leftLimit = -30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // FIX 1: Changed '>' to '<' to correctly check if it went past the left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        // FIX 2: Changed '.z' to '.y' to correctly match the Y-axis (bottom limit)
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}