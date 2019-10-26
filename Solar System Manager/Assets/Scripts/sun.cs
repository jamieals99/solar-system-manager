using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class sun : MonoBehaviour
{
    [SerializeField]
    private GameObject PlanetPrefab; //planet prefab object

    public static float countPlanets = 1;

    [SerializeField]
    private Transform rotatingObject; // Variable for storing the transform of the object that you want to rotate.
    [SerializeField]
    private float rotationSpeed = 60f; // Adjust this value to increase the speed of rotation.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //If space key is pressed creates planet
        {
            CreatePlanet();
            countPlanets ++;
        }

        
    }



        void CreatePlanet() //start at position 0,0,-8 radius increasing by 4 each time.
    {
        Instantiate(PlanetPrefab, new Vector3(0, 0, -8 - (countPlanets * 4)), Quaternion.identity);
    }

    
}
