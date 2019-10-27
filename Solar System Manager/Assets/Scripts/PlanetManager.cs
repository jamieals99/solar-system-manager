using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetManager : MonoBehaviour
{
    //public GameObject planet;
    public GameObject[] planets; // Array of all planets in order
    public GameObject[] orbits; // Array of all orbits in order
    public GameObject[] buttons; //Array of planetButtons in order
    public int planetNumber = 1; // reference to array, starts at 0, counts up when Planets get added
    public int orbitNumber = 1; //reference to array, starts at 0, counts up when Orbits get added
    public int buttonNumber = 1; //reference to array, starts at 0, counts up when Button get added
    private GameObject selectedPlanet;
    private GameObject[] allPlanets;

    
    //private Button btn0;
    //private Button btn1;
    //private Button btn2;
    //private Button btn3;
    //private Button btn4;
    //private Button btn5;
    //private Button btn6;
    //private Button btn7;


    private GameObject[] infoPanels;

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

        //btn0 = buttons[0].GetComponent<Button>();
        //btn1 = buttons[1].GetComponent<Button>();
        //btn2 = buttons[2].GetComponent<Button>();
        //btn3 = buttons[3].GetComponent<Button>();
        //btn4 = buttons[4].GetComponent<Button>();
        //btn5 = buttons[5].GetComponent<Button>();
        //btn6 = buttons[6].GetComponent<Button>();
        //btn7 = buttons[7].GetComponent<Button>();

    }


    public void Update()
    {
        //btn0.onClick.AddListener(SelectPlanet);


        //Moving Camera out when Planet is created - must be in update function for smooth movement transition
        if (zoomOut == false)
        {
            mainCamera.fieldOfView = Mathf.MoveTowards(mainCamera.fieldOfView, targetFOV, cameraSpeed * Time.deltaTime);
            if (mainCamera.fieldOfView == targetFOV)
            {
                zoomOut = true;
            }
        }


        // Clicking on a planet selects it and activates Outline
        //if (Input.GetMouseButtonDown(0))
        //{

        //    RaycastHit planetClick = new RaycastHit();
        //    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out planetClick);

        //    if (hit)
        //    {

        //        if (planetClick.transform.gameObject.tag == "Planet")
        //        {

        //            allPlanets = GameObject.FindGameObjectsWithTag("Planet");

        //            foreach (GameObject planet in allPlanets)
        //            {
        //                planet.GetComponent<Outline>().enabled = false;
        //            }

        //            selectedPlanet = planetClick.transform.gameObject;

        //            selectedPlanet.GetComponent<Outline>().enabled = true;
        //        }

        //    }

        //}
    }


    public void CreatePlanet()
    {
        if (planetCost > ResourceGeneration.resources || planets[7].activeSelf == true)
        {
            return;
        }

        ResourceGeneration.resources = ResourceGeneration.resources - planetCost;

        planets[planetNumber].SetActive(true);
        orbits[orbitNumber].SetActive(true);
        buttons[buttonNumber].SetActive(true);

        orbitNumber++;
        planetNumber++;
        buttonNumber++;

        planetCost = Mathf.Pow(planetNumber + 1, 2.75f);
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
