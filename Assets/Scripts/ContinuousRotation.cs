using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationSpeed = 200f; // Rotation speed in degrees per second

    void Update()
    {
        // Calculate the rotation amount based on the time and rotation speed
        float rotationAmount = -rotationSpeed * Time.deltaTime;

        // Apply the rotation to the object's transform
        transform.Rotate(0f, 0f, rotationAmount);
    }
}
