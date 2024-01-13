using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Durability : MonoBehaviour
{
	// getting the enemy data
    [SerializeField] public EnemyData Triangle;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject triangle;
    //player attributes
    public double newHealth;
    public double newSpeed;
    public Shield_Guard guardAbility;
    public bool immune;

    public double cooldown;

    public PlayerAttributes player;
    // Start is called before the first frame update
    void Start()
    {
        guardAbility = new Shield_Guard();
        spawnRate = Triangle.spawnRate;
        timeToSpawn = spawnRate;
        //creating the triangle enemy
        triangle = new GameObject();
        triangle.AddComponent(typeof(EnemyData));
    }
    public void enterDimension(PlayerAttributes player)
    {
        this.player = player;
        this.player.dimensionChangeDurability(newHealth, newSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        //check if attacked
        if (Input.GetKey(KeyCode.F))
        {
            if (guardAbility.TriggerAbility())
            {
                immune = true;
                //print successful ability
            }
            else
            {
                cooldown = guardAbility.getCooldown();
                //print cooldown
            }
        }
        if (immune)
        {
            if (guardAbility.checkImmunity()==false)
            {
                immune = false;
                //print ability ended
            }
        }

        if (timeToSpawn > 0.0)
        {
            timeToSpawn -= Time.deltaTime;
        }
        else
        {
            spawnNew();
            timeToSpawn = spawnRate;
        }
    }

    void isAttacked(double damage)
    {
        //called if the beenAttacked Event is raised
        if (immune==false)
        {
            player.changeHealth(damage);
            if (player.getAlive() == false)
            {
                //end the game
                exitDimension();
            }
        }
    }
    void spawnNew()
    {
        Instantiate(triangle);
    }
    public PlayerAttributes exitDimension()
    {
        //end the instance of Shield_Guard
        return player;
    }
}
