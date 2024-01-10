using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public double newHealth;
    public Wakizashi_Counter counter;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        counter = new Wakizashi_Counter();
    }
    void enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeSpeed(newHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            valid = counter.TriggerAbility();
            if (valid)
            {
                immune = true;
                //print successful ability
            }
            else
            {
                //print failed ability
            }
        }
        //check if attacked, then chek if the ability is active
    }
}
