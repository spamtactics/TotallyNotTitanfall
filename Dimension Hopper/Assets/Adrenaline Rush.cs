using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineRush : MonoBehaviour
{
    public double currentCooldown;
    public double baseCooldown;
    public double currentAbilityDuration;
    public double baseAbilityDuration;
    public bool abilityUsed;
    public bool abilityInUse;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0.0;
        abilityInUse = false;
        abilityUsed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (abilityInUse){
            if (abilityUsed)
            {
                currentAbilityDuration = currentAbilityDuration - Time.deltaTime;
                if (currentAbilityDuration <= 0)
                {
                    AbilityEnd();
                }
            }
            else
            {
                currentCooldown = currentCooldown - Time.deltaTime;
            }
        }
    }
    public bool TriggerAbility()
    {
        if (currentCooldown<=0)
        {
            abilityUsed = true;
            currentAbilityDuration = baseAbilityDuration;
            return true;
        }
        else
        {
            return false;
        }
    }
    void AbilityEnd()
    {
        abilityUsed = false;
        currentCooldown = baseCooldown;
    }
    public double getCooldown()
    {
        return currentCooldown;
    }

    public bool getActive()
    {
        return abilityUsed;
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
