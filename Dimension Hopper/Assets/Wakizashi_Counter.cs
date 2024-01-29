using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wakizashi_Counter : MonoBehaviour
{
    public double currentCooldown;
    public double baseCooldown=5f;
    public double currentAbilityDuration;
    public double baseAbilityDuration=0.2f;
    public bool successfulCounter;
    public bool abilityUsed;
    public double cooldownReduction=3f;

    public bool abilityInUse;
    //initialise a timer object
    
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0f;
        abilityUsed = false;
        abilityInUse = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (abilityInUse){
            if (abilityUsed)
            {
                if (currentAbilityDuration <= 0f)
                {
                    abilityEnd();
                }
                else
                {
                    currentAbilityDuration = currentAbilityDuration - Time.deltaTime;
                }
            }
            else if (currentCooldown > 0f)
            {
                currentCooldown = currentCooldown - Time.deltaTime;
            }
        }
    }
    public bool TriggerAbility()
    {
        if (currentCooldown <= 0f)
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
