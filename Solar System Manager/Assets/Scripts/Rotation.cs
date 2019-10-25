using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField]
    private Transform rotatingObject; // Variable for storing the transform of the object that you want to rotate.
    [SerializeField]
    private float rotationSpeed = 60f; // Adjust this value to increase the speed of rotation.

    void FixedUpdate()
    {
        rotatingObject.Rotate(0, (rotationSpeed * Time.deltaTime), 0); // Rotates the object on its y axis only.
    }
}
