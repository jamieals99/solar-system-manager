using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlanetManager : MonoBehaviour
{
    //public GameObject planet;
    public GameObject[] planets; // Array of all planets in order
    public GameObject[] orbits; // Array of all orbits in order
    public int planetNumber = 1; // reference to array, starts at 0, counts up when Planets get added
    public int orbitNumber = 1; //reference to array, starts at 0, counts up when Orbits get added
   
    private Camera mainCamera;
    public float startFOV = 20;
    public float fovAddition = 15; // Amount by which FOC increases when creating a planet
    private float targetFOV;
    public float cameraSpeed = 1;

    private bool zoomOut = true;

    // Start is called before the first frame update
    void Start()
    {
       
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCamera.fieldOfView = startFOV;
    }


    public void Update()
    {
        if (zoomOut == false)
        {


            mainCamera.fieldOfView = Mathf.MoveTowards(mainCamera.fieldOfView, targetFOV, cameraSpeed * Time.deltaTime);
            if (mainCamera.fieldOfView == targetFOV)
            {
                zoomOut = true;
            }
        }
    }

    public void CreatePlanet()
    {
        planets[planetNumber].SetActive(true);
        orbits[orbitNumber].SetActive(true);

        orbitNumber++;
        planetNumber++;

        targetFOV = mainCamera.fieldOfView + fovAddition;

        zoomOut = false;
    }
}
