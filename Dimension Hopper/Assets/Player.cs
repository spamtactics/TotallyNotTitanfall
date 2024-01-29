using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject player;
    public double health=100;
    public int currentDimension;
    public int targetDimension;
    public Durability durabilityDimension;
    public Speed speedDimension;
    public Time_Dimension timeDimension;
    public DimensionSwapper swapper;
    public NavMeshAgent playerSpeed;
    void Start()
    {
        //remember to name the player gameObject player
        player = GameObject.Find("Player");
        swapper = player.GetComponent<DimensionSwapper>();
        durabilityDimension = player.GetComponent<Durability>();
        speedDimension = player.GetComponent<Speed>();
        timeDimension = player.GetComponent<Time_Dimension>();
        playerSpeed = player.GetComponent<NavMeshAgent>();
        playerSpeed.speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (getAlive() == false)
        {
            //end the game
            Application.Quit();
        }
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
                currentDimension = targetDimension;
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
        this.health -= health;
    }
    public void dimensionChangeDurability(double health, float speed)
    {
        playerSpeed.speed = speed;
        this.health += health;
    }

    public void changeHealth(double deltaHealth)
    {
        if (swapper.checkSwapping()==false){
            switch (currentDimension)
            {
                case 1:
                    if (durabilityDimension.getImmune() == false)
                    {
                        health = health - deltaHealth;
                    }

                    break;
                case 2:
                    if (speedDimension.getCounter() == false)
                    {
                        health = health - deltaHealth;
                    }

                    break;
                default:
                    health = health - deltaHealth;
                    break;
            }
        }
    }

    public void adrenalineRush()
    {
        playerSpeed.speed = playerSpeed.speed * 2;
    }

    public void endAdrenalineRush()
    {
        playerSpeed.speed = playerSpeed.speed / 2;
    }

    public void startGuard()
    {
        playerSpeed.speed = 0;
    }

    public void endGuard()
    {
        playerSpeed.speed = 1;
    }

    bool getAlive()
    {
        if (health < 0)
        {
            return false;
        }
        return true;
    }
}

