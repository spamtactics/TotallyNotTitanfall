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
    // Start is called before the first frame update
    void Start()
    {
        //dont think I need this
    }

    // Update is called once per frame
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
        switch (dimensionNum)
        {
            case 1:
                //insert the durability game object
            case 2:
                //insert the speed game object
            case 3:
                //insert the "" game object
            case 4: 
                //insert the "" game object
            case 5:
                //insert the "" game object
            default:
                return;
        }
    }
    void AbilityEnd()
    {
        isSwapping = false;
        currentCooldown = baseCooldown;
    }

    bool TriggerSwap()
    {
        if (currentCooldown<=0)
        {
            isSwapping = true;
            currentSwapDuration = baseSwapDuration;
            return true;
        }
        else
        {
            return false;
        }
    }
}
