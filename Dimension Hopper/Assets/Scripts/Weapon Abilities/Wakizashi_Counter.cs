using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wakizashi_Counter : MonoBehaviour
{
    public float currentCooldown;

    public float baseCooldown;

    public float currentAbilityDuration;

    public float baseAbilityDuration;

    public bool succesfulCounter;

    public bool abilityUsed;
    // Start is called before the first frame update
    
    
    void Start()
    {
        currentCooldown = 0;
        
    }

    // Update is called once per frame
    void TriggerAbility()
    {
        abilityUsed = true;
        currentAbilityDuration = 0;
        
    }
    void Update()
    {
        
    }
}
