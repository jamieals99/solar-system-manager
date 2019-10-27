using System.Collections;
using UnityEngine;

public class ResourceGeneration : MonoBehaviour
{

    public static float resources = 0;
    private void Start()
    {
        StartCoroutine(ResourceGen());
    }

    private IEnumerator ResourceGen()
    {
        if (gameObject.tag == "Planet")
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                resources += 1f * gameObject.transform.lossyScale.x;
                //Debug.Log("Resources: " + resources);
            }
        }
        else if (gameObject.tag == "Moon")
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                resources += 0.25f;
                //Debug.Log("Resources: " + resources);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}