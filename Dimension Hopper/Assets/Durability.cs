using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Durability : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public bool inDimension;
	// getting the enemy data
    public double spawnRate=5f;
    public double timeToSpawn;
    public double enemyDamage = 50;
    public double attackWindup=0.75f;
    public GameObject triangle;
    public attackPlayer attackPlayer;
    public NavMeshAgent enemySpeed;
    //player attributes
    public double newHealth=10.0;
    public float newSpeed=3;
    public Shield_Guard guardAbility;
    public bool immune;
    
    public double cooldown;
    //weapon attributes
    public double attackFrequency=1f;
    public double attackCooldown;
    public double damage=10;
    public GameObject attackBox;
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
        triangle.AddComponent<EnemyNavigation>();
        triangle.AddComponent<NavMeshAgent>();
        enemySpeed = triangle.GetComponent<NavMeshAgent>();
        enemySpeed.speed = 4;
        //assigning the attackPlayer script to it
        triangle.AddComponent<attackPlayer>();
        attackPlayer=triangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(enemyDamage, attackWindup);
        guardAbility = playerObject.GetComponent<Shield_Guard>();
        //getting weapon attributes
        attackBox = new GameObject();
        attackBox.AddComponent<attackEnemy>();
        bash=attackBox.GetComponent<attackEnemy>();
        bash.updateDamage(damage);
    }
    public void enterDimension()
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
        guardAbility.EnterDimension();
        attackCooldown = 0f;
        inDimension = true;
    }
    // Update is called once per frame
    void Update()
        {
            if(inDimension){
                if (attackCooldown > 0.0f)
                {
                    attackCooldown -= Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (attackCooldown <= 0f)
                    {
                        Bash();
                        attackCooldown = attackFrequency;
                        Debug.Log("Attack");
                    }
                }

                if (Input.GetKey(KeyCode.F))
                {
                    if (guardAbility.TriggerAbility())
                    {
                        immune = true;
                        player.startGuard();
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
                        player.endGuard();
                        immune = false;
                        //print ability ended
                    }
                }

                if (timeToSpawn > 0.0f)
                {
                    timeToSpawn -= Time.deltaTime;
                }
                else
                {
                    timeToSpawn = spawnRate;
                    spawnNew();
                }
            }
    }
    public bool getImmune()
    {
        return immune;
    }

    void Bash()
    {
        Instantiate(attackBox);
    }
    void spawnNew()
    {
        Instantiate(triangle);
    }

    public void exitDimension()
    {
        //resetting player attributes
        player.dimensionChangeDurability(-10,4);
        inDimension = false;
        guardAbility.ExitDimension();
    }
}
