using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{

    public GameObject PlanetLocation;
    public GameObject CameraLocation;
    public Vector3 Offset;
    public Vector3 StartLocation;
    public Vector3 AfterhitLocation;
    public Vector3 CameraPosition2 = new Vector3(0f, 90f, 16f);
    public float xAxis, yAxis, zAxis;
    public Vector3 StartRotation;
    public float StartXRotation = 15f;
    public float StartYRotation = 0f;
    public float StartZRotation = 0f;
    public Vector3 HitLocation;
    public bool Apressed = true;
    public Orbit orbit;
    public int Acounter = 0;
    public PlanetManager manager;
    // Start is called before the first frame update
    public void Start()
    {
        manager = GameObject.Find("PlanetManager").GetComponent<PlanetManager>();
        StartLocation = CameraLocation.transform.position;
        StartRotation = new Vector3(StartXRotation, StartYRotation, StartZRotation);
        Debug.Log("Location: " + StartLocation);
        Offset = CameraLocation.transform.position - PlanetLocation.transform.position;
    }
    public Vector3 SwapCameraLocation(int counter)
    {
        if (Acounter == -1)
        {
            AfterhitLocation = StartLocation;
            return AfterhitLocation + Offset;
        }
        else
        {
            AfterhitLocation = manager.planets[counter].transform.position;
            Debug.Log(manager.planets[Acounter].transform.position);
            Debug.Log(AfterhitLocation);
            return AfterhitLocation + Offset;
        }
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = SwapCameraLocation(Acounter);
        if (Input.GetKeyDown("a"))
        {
            if (Acounter > 8)
            {
                Acounter = 8;
            }
            else
            {
                Acounter += 1;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            if(Acounter < -1)
            {
                Acounter = -1;
            }
            else
            {
                Acounter -= 1;
            }
        }
    }
}
