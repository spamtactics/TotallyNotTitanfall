using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public double health;
    public double speed;
    public bool immunity;
    void Start()
    {
        immunity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //insert script to 
    }

    void dimensionChangeSpeed(health)
    {
        this.health = health;
    }
    void dimensionChangeDurability(speed)
    {
        this.speed = speed;
    }

    bool getImmunity()
    {
        return immunity;
    }
}
