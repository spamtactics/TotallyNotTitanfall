using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public double newHealth;

    public double newSpeed;

    public Shield_Guard guardAbility;

    public bool valid;
    // Start is called before the first frame update
    void Start()
    {
        guardAbility = new Shield_Guard();
    }
    void enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        //check if attacked
        if (Input.GetKey(KeyCode.F))
        {
            valid = guardAbility.TriggerAbility();
            if (valid)
            {
                //print successful ability
            }
            else
            {
                //print failed ability
            }
        }
    }
}
