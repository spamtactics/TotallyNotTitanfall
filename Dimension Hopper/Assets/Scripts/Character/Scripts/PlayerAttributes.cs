using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public double health;
    public double speed;

    // Update is called once per frame
    void Update()
    {
        //might just delete this
    }
    public void dimensionChangeSpeed(double health)
    {
        this.health = health;
    }
    public void dimensionChangeDurability(double health, double speed)
    {
        this.speed = speed;
        this.health = health;
    }

    public void changeHealth(double deltaHealth)
    {
        health = health - deltaHealth;
    }
}
