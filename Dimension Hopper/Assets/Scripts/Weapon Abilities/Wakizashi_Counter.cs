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
            currentAbilityDuration = currentAbilityDuration - Time.deltaTime;
        }
        else if(currentCooldown>0)
        {
            currentCooldown = currentCooldown - Time.deltaTime;
        }
    }
    void TriggerAbility()
    {
        if (currentCooldown <= 0)
        {
            currentAbilityDuration = baseAbilityDuration;
        }
        else
        {
            // return some sort of error
        }
    }
    
    void SuccessfulCounter()
    {
        currentCooldown = baseCooldown - cooldownReduction;
        abilityUsed = false;
    }

    double getCurrentDuration()
    {
        return currentAbilityDuration;
    }
    void abilityEnd()
    {
        abilityUsed = false;
        currentCooldown = baseCooldown;
    }
}
