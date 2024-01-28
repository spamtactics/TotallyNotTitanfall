using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwapper : MonoBehaviour
{
    public GameObject playerObject;
    public double baseCooldown=10.0;
    public double currentCooldown;
    public double baseSwapDuration=0.5;
    public double currentSwapDuration;
    public bool isSwapping;
    public Durability durabilityDimension;

    public Speed speedDimension;

    public Time_Dimension timeDimension;
    public Player player;

    public int currentDimension;
    // Start is called before the first frame update
    void Start()
    {
        currentDimension = 0;
        playerObject = GameObject.Find("Player");
        player=playerObject.GetComponent<Player>();
        durabilityDimension=playerObject.GetComponent<Durability>();
        speedDimension=playerObject.GetComponent<Speed>();
        timeDimension=playerObject.GetComponent<Time_Dimension>();
    }

    // Update is called once per frame

    void Update()
    {
        if (isSwapping)
        {
            currentSwapDuration = currentSwapDuration - Time.deltaTime;
            if (currentSwapDuration <= 0)
            {
                Debug.Log("Swap cooldown reset");
                isSwapping = false;
                currentCooldown = baseCooldown;
            }
        }
        else
        {
            currentCooldown = currentCooldown - Time.deltaTime;
        }
    }

    void dimensionSwap(int dimensionNum)
    {
        switch (currentDimension)
        {
            case 1:
                durabilityDimension.exitDimension();
                break;
            case 2:
                speedDimension.exitDimension();
                break;
            case 3:
                timeDimension.exitDimension();
                break;
            default:
                break;
        }
        switch (dimensionNum)
        {
            case 1:
                durabilityDimension.enterDimension();
                break;
            case 2:
                speedDimension.enterDimension();
                break;
            case 3:
                timeDimension.enterDimension();
                break;
            default:
                break;
        }
        currentDimension = dimensionNum;
    }

    public bool TriggerSwap(int targetDimension)
    {
        if (currentCooldown<=0)
        {
            isSwapping = true;
            currentSwapDuration = baseSwapDuration;
            dimensionSwap(targetDimension);
            return true;
        }
        else
        {
            return false;
        }
    }

    public double getCooldown()
    {
        return currentCooldown;
    }
    public bool checkSwapping()
    {
        return isSwapping;
    }
}

