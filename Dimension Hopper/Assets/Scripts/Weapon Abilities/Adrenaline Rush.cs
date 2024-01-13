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
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0.0;
        abilityUsed = false;
    }
    // Update is called once per frame
    void Update()
    {
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
}
