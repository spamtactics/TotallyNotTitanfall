using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public double newHealth;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        //might just delete this
    }
    void enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeSpeed(newHealth);
    }
    // Update is called once per frame
    void Update()
    {
        //not sure what to put here
    }
}
