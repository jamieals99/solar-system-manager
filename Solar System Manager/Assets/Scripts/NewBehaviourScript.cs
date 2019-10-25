using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject PlanetLocation;
    public Vector3 Offset;
    public Vector3 StartLocation;
    public Vector3 AfterOffset;
    public float xAxis, yAxis, zAxis;
    // Start is called before the first frame update
    void Start()
    {
        StartLocation = transform.position;
        Debug.Log("Location: " + StartLocation);
        Offset = transform.position - PlanetLocation.transform.position;
        transform.position = transform.position + Offset;
        AfterOffset = transform.position;
        Debug.Log("Location: " + AfterOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            
        }
    }
}
