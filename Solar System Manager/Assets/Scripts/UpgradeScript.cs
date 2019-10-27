using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public int maxSizeUpgradeCount = 5;
    public int sizeUpgradeCount;
    public int sizeUpgradeCost = 10;
    public int maxSpeedUpgradeCount = 5;
    public int speedUpgradeCount;
    public int speedUpgradeCost = 10;
    public int moonCost = 25;
    private int moonNumber = 0;
    public GameObject[] moons;
    void Update()
    {

    }

    public void UpgradeSize()
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

    public void UpgradeSpeed()
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
    public void AddMoon()
    {
        if (moonCost > ResourceGeneration.resources)
        {
            return;
        }
        moons[moonNumber].SetActive(true);
        moonNumber++;
        ResourceGeneration.resources = ResourceGeneration.resources - moonCost;
    }
}
