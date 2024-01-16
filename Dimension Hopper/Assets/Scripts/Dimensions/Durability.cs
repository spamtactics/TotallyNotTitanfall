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
    public attackPlayer attackPlayer;
    //player attributes
    public double newHealth;
    public double newSpeed;
    public Shield_Guard guardAbility;
    public bool immune;
    
    public double cooldown;
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
    public PlayerAttributes enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
        attackPlayer.fillInData(Triangle, player);
        triangle.AddComponent(typeof(attackPlayer));
        return player;
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
    public bool getImmune()
    {
        return immune;
    }
    
    void spawnNew()
    {
        Instantiate(triangle);
    }

    public void exitDimension()
    {
        // delete current instance of shield guard
    }
}
