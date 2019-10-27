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

    public static float planetCost = 0;
    private bool firstPlanetAdded = false;
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
        if(planetCost > ResourceGeneration.resources || planets[7].activeSelf == true)
        {
            return;
        }

        ResourceGeneration.resources = ResourceGeneration.resources - planetCost;

        planets[planetNumber].SetActive(true);
        orbits[orbitNumber].SetActive(true);

        orbitNumber++;
        planetNumber++;

        
        planetCost = Mathf.Pow(planetNumber+1,2.75f);
        if (!firstPlanetAdded && planets[0].activeSelf == true)
        {
            planetCost = 10;
            firstPlanetAdded = true;
        }
        Debug.Log("Planet Cost: " + planetCost);

        targetFOV = mainCamera.fieldOfView + fovAddition;

        zoomOut = false;
    }
}
