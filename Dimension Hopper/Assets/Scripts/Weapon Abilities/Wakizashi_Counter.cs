using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class Wakizashi_Counter : MonoBehaviour
{
    public double currentCooldown;
    public double baseCooldown;
    public double currentAbilityDuration;
    public double baseAbilityDuration;
    public bool successfulCounter;
    public bool abilityUsed;
    public double cooldownReduction;
    //initialise a timer object
    
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0;
        abilityUsed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (abilityUsed)
        {
            if (successfulCounter)
            {
                SuccessfulCounter();
            }
            else if(currentAbilityDuration<=0)
            {
                abilityEnd();
            }
            else
            {
                currentAbilityDuration = currentAbilityDuration - Time.deltaTime;
            }
        }
        else if(currentCooldown>0)
        {
            currentCooldown = currentCooldown - Time.deltaTime;
        }
    }
    bool TriggerAbility()
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
    bool attacked()
    {
        if (abilityUsed==true)
        {
            successfulCounter = true;
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
}
