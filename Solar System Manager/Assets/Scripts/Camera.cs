using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject PlanetLocation;
    public GameObject CameraLocation;
    public Vector3 Offset;
    public Vector3 StartLocation;
    public Vector3 CameraPosition2 = new Vector3(0f,90f,16f);
    public float xAxis, yAxis, zAxis;
    public Vector3 StartRotation;
    public float StartXRotation = 15f;
    public float StartYRotation = 0f;
    public float StartZRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartLocation = CameraLocation.transform.position;
        StartRotation = new Vector3(StartXRotation, StartYRotation, StartZRotation);
        Debug.Log("Location: " + StartLocation);
        Offset = CameraLocation.transform.position - PlanetLocation.transform.position;
        transform.position = StartLocation + Offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            transform.position = StartLocation;
            transform.position += CameraPosition2;
            transform.Rotate(75f, 0f, 0f);
        }
        if(Input.GetKeyUp("a"))
        {
            transform.Rotate(-75f, 0f , 0f);
            transform.position = StartLocation;
            transform.position += Offset;
        }
    }
}
