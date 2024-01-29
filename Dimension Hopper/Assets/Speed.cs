using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Speed : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public bool inDimension;
    //enemy data
    public double spawnRate=5f;
    public double timeToSpawn;
    public double enemyDamage=20;
    public double attackWindup=0.5f;
    public GameObject rectangle;
    public attackPlayer attackPlayer;
    public NavMeshAgent enemySpeed;
    
    public double newHealth=10.0;
    public Wakizashi_Counter counter;
    public double cooldown;

    public double attackFrequency=0.5f;

    public double attackCooldown;
    public double damage=10;

    public GameObject attackBox;

    public attackEnemy slash;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        //getting the player
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        //setting up the enemy gameobject
        rectangle = new GameObject();
        //adding the Enemy data
        rectangle.AddComponent(typeof(EnemyNavigation));
        rectangle.AddComponent<NavMeshAgent>();
        enemySpeed = rectangle.GetComponent<NavMeshAgent>();
        enemySpeed.speed = 6;
        rectangle.AddComponent<attackPlayer>();
        attackPlayer=rectangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(enemyDamage, attackWindup);
        counter = playerObject.GetComponent<Wakizashi_Counter>();
        attackBox = new GameObject();
        attackBox.AddComponent<attackEnemy>();
        slash = attackBox.GetComponent<attackEnemy>();
        slash.updateDamage(damage);
    }
    public void enterDimension()
    {
        player.dimensionChangeSpeed(newHealth);
        counter.EnterDimension();
        attackCooldown = 0f;
        inDimension = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(inDimension){
            if (Input.GetKey(KeyCode.F))
            {
                if (counter.TriggerAbility())
                {
                    //print successful ability
                }
                else
                {
                    cooldown = counter.getCooldown();
                    //print cooldown
                }
            }

            if (attackCooldown > 0.0f)
            {
                attackCooldown -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (attackCooldown < 0.0f)
                {
                    Slash();
                    attackCooldown = attackFrequency;
                }
            }

            if (timeToSpawn > 0.0f)
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
    void Slash()
    {
        Instantiate(attackBox);
    }
    void spawnNew()
    {
        Instantiate(rectangle);
    }
    public bool getCounter()
    {
        if (counter.counter())
        {
            //say successful counter
            return true;
        }
        else
        {
            return false;
        }
    }

    public void exitDimension()
    {
        //resetting player health
        player.dimensionChangeSpeed(-10);
        inDimension = false;
        counter.ExitDimension();
    }
}
