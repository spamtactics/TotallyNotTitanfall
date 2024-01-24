using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Durability : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public bool inDimension;
	// getting the enemy data
    public double spawnRate;
    public double timeToSpawn;
    public double enemyDamage;
    public double attackWindup;
    public GameObject triangle;
    public attackPlayer attackPlayer;
    //player attributes
    public double newHealth=10.0;
    public double newSpeed=0.75;
    public Shield_Guard guardAbility;
    public bool immune;
    
    public double cooldown;
    //weapon attributes
    public double attackFrequency;
    public double attackCooldown;
    public double damage;
    public GameObject Hitbox;
    public attackEnemy bash;
    // Start is called before the first frame update
    void Start()
    {
        //getting the player
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        //setting up the enemy
        timeToSpawn = spawnRate;
        triangle = new GameObject();
        //assigning the triangle data to it
        triangle.AddComponent(typeof(EnemyNavigation));
        //assigning the attackPlayer script to it
        triangle.AddComponent(typeof(attackPlayer));
        attackPlayer=triangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(enemyDamage, attackWindup);
        guardAbility = playerObject.GetComponent<Shield_Guard>();
        //getting weapon attributes
        Hitbox.AddComponent(typeof(attackEnemy));
        bash=Hitbox.GetComponent<attackEnemy>();
        bash.updateDamage(damage);
    }
    public void enterDimension()
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
        guardAbility.EnterDimension();
        attackCooldown = 0;
        inDimension = true;
    }
    // Update is called once per frame
    void Update()
        {
            if(inDimension){
                if (attackCooldown > 0.0)
                {
                    attackCooldown -= Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (attackCooldown <= 0)
                    {
                        Bash();
                        attackCooldown = attackFrequency;
                    }
                }

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
                    if (guardAbility.checkImmunity() == false)
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
    }
    public bool getImmune()
    {
        return immune;
    }

    void Bash()
    {
        Instantiate(Hitbox);
    }
    void spawnNew()
    {
        Instantiate(triangle);
    }

    public void exitDimension()
    {
        inDimension = false;
        guardAbility.ExitDimension();
    }
}
