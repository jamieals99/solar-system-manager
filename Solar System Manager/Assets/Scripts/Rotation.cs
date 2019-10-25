using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    [SerializeField]
    private Transform rotater;
    [SerializeField]
    private float rotationSpeed = 60f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotater.Rotate(0, (rotationSpeed * Time.deltaTime), 0);
    }
}
