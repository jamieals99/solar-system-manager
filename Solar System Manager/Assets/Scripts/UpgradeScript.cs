using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public static int maxSizeUpgradeCount = 5;
    public static int sizeUpgradeCount;
    public static int sizeUpgradeCost = 10;
    public static int maxSpeedUpgradeCount = 5;
    public static int speedUpgradeCount;
    public static int speedUpgradeCost = 10;
    
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            UpgradeSize();
        }
        if(Input.GetKeyDown("d"))
        {
            UpgradeSpeed();
        }

    }

    void UpgradeSize()
    {
        if (sizeUpgradeCost > ResourceGeneration.resources)
        {
            return;
        }

        if (sizeUpgradeCount < maxSizeUpgradeCount) 
        {
            gameObject.transform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
            ResourceGeneration.resources = ResourceGeneration.resources - sizeUpgradeCost;
            sizeUpgradeCount++;
            sizeUpgradeCost += 10;
            Debug.Log("Size upgrade cost: " + sizeUpgradeCost);
        }
        else
        {
            return;
        }
    }

    void UpgradeSpeed()
    {
        if (speedUpgradeCost > ResourceGeneration.resources)
        {
            return;
        }

        if (speedUpgradeCount < maxSpeedUpgradeCount)
        {
            var speed = gameObject.GetComponent<Orbit>();
            speed.orbitSpeed += 30;
            ResourceGeneration.resources = ResourceGeneration.resources - speedUpgradeCost;
            speedUpgradeCount++;
            speedUpgradeCost += 10;
            Debug.Log("Speed upgrade cost: " + speedUpgradeCost);
        }
        else
        {
            return;
        }
    }

}
