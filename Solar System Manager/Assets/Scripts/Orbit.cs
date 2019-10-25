using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private Transform centre;
    [SerializeField]
    private Vector3 axis;
    [SerializeField]
    private float radius = 2f;
    [SerializeField]
    private float radiusSpeed = 0.5f;
    [SerializeField]
    private float rotationSpeed = 60f;

    void Start()
    {
        transform.position = (transform.position - centre.position).normalized * radius + centre.position;
    }

    void FixedUpdate()
    {
        transform.RotateAround(centre.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - centre.position).normalized * radius + centre.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }
}
