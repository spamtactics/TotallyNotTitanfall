using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public double health;
    public double speed;
    public int currentDimension;
    public int targetDimension;
    public Durability durabilityDimension;
    public Speed speedDimension;
    public TimeDimension timeDimension;
    public DimensionSwap swapper;
    void Start()
    {
        swapper = new DimensionSwap();
        durabilityDimension = new Durability();
        speedDimension = new Speed();
        timeDimension = new TimeDimension();
        swapper.feedDimensions(durabilityDimension,speedDimension,timeDimension);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            targetDimension = 1;
            //durability
        }
        else if (Input.GetKey(KeyCode.K))
        {
            targetDimension = 2;
            //speed
        }
        else if (Input.GetKey(KeyCode.L))
        {
            targetDimension = 3;
            //time
        }

        if (targetDimension == currentDimension)
        {
            //raise some sort of error
        }
        else
        {
            if (swapper.TriggerSwap(targetDimension))
            {
                //say successful
            }
            else
            {
                swapper.getCooldown();
                //print cooldown
            }
        }
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
        switch (currentDimension)
        {
            case 1:
                break;
        }
    }

    public void adrenalineRush()
    {
        speed = speed * 2;
    }

    public void endAdrenalineRush()
    {
        speed = speed / 2;
    }

    public bool getAlive()
    {
        if (health < 0)
        {
            return false;
        }
        return true;
    }
}
