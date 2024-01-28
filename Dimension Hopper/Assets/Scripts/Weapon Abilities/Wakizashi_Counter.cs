using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wakizashi_Counter : MonoBehaviour
{
    public double currentCooldown;
    public double baseCooldown;
    public double currentAbilityDuration;
    public double baseAbilityDuration;
    public bool successfulCounter;
    public bool abilityUsed;
    public double cooldownReduction;

    public bool abilityInUse;
    //initialise a timer object
    
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0;
        abilityUsed = false;
        abilityInUse = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (abilityInUse){
            if (abilityUsed)
            {
                if (currentAbilityDuration <= 0)
                {
                    abilityEnd();
                }
                else
                {
                    currentAbilityDuration = currentAbilityDuration - Time.deltaTime;
                }
            }
            else if (currentCooldown > 0)
            {
                currentCooldown = currentCooldown - Time.deltaTime;
            }
        }
    }
    public bool TriggerAbility()
    {
        if (currentCooldown <= 0)
        {
            currentAbilityDuration = baseAbilityDuration;
            successfulCounter = false;
            abilityUsed = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool counter()
    {
        if (abilityUsed==true)
        {
            successfulCounter = true;
            SuccessfulCounter();
            return true;
        }
        else
        {
            return false;
        }
    }
    void SuccessfulCounter()
    {
        currentCooldown = baseCooldown - cooldownReduction;
        abilityUsed = false;
    }
    void abilityEnd()
    {
        abilityUsed = false;
        currentCooldown = baseCooldown;
    }

    public double getCooldown()
    {
        return currentCooldown;
    }
    public void ExitDimension()
    {
        abilityInUse = false;
    }

    public void EnterDimension()
    {
        abilityInUse = true;
    }
}
