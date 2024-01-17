using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwap : MonoBehaviour
{
    public double baseCooldown;
    public double currentCooldown;
    public double baseSwapDuration;
    public double currentSwapDuration;
    public bool isSwapping;
    public Durability durabilityDimension;

    public Speed speedDimension;

    public TimeDimension timeDimension;

    public PlayerAttributes player;

    public int currentDimension;
    // Start is called before the first frame update
    void Start()
    {
        // should you automatically start in a dimension?
    }

    public void feedDimensions(Durability durability, Speed speed, TimeDimension time)
    {
        durabilityDimension = durability;
        speedDimension = speed;
        timeDimension = time;
    }
    // Update is called once per frame
    public void getPlayer(PlayerAttributes player)
    {
        this.player = player;
    }
    void Update()
    {
        if (isSwapping)
        {
            currentSwapDuration = currentSwapDuration - Time.deltaTime;
            if (currentSwapDuration <= 0)
            {
                AbilityEnd();
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
                durabilityDimension.enterDimension(player);
                break;
            case 2:
                speedDimension.enterDimension(player);
                break;
            case 3:
                timeDimension.enterDimension(player);
                break;
            default:
                break;
        }
        currentDimension = dimensionNum;
    }
    void AbilityEnd()
    {
        isSwapping = false;
        currentCooldown = baseCooldown;
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
