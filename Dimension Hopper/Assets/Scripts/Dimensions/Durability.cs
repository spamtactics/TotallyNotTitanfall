using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durability : MonoBehaviour
{
    public double newHealth;

    public double newSpeed;
    //Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        //might just delete this
    }
    void enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        //not sure what to put here
    }
}
