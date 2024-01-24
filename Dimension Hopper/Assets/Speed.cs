using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject playerObject;
    public Player player;
    public bool inDimension;
    //enemy data
    public double spawnRate;
    public double timeToSpawn;
    public double enemyDamage;
    public double attackWindup;
    public GameObject rectangle;
    public attackPlayer attackPlayer;
    public double newHealth=10.0;
    public Wakizashi_Counter counter;
    public double cooldown;

    public double attackFrequency;

    public double attackCooldown;
    public double damage;

    public GameObject hitbox;

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
        //adding the attackPlayer script
        rectangle.AddComponent(typeof(attackPlayer));
        attackPlayer=rectangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(enemyDamage, attackWindup);
        counter = playerObject.GetComponent<Wakizashi_Counter>();
        hitbox.AddComponent(typeof(attackEnemy));
        slash = hitbox.GetComponent<attackEnemy>();
        slash.updateDamage(damage);
    }
    public void enterDimension()
    {
        player.dimensionChangeSpeed(newHealth);
        counter.EnterDimension();
        attackCooldown = 0;
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

            if (attackCooldown > 0.0)
            {
                attackCooldown -= Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (attackCooldown < 0.0)
                {
                    Slash();
                    attackCooldown = attackFrequency;
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
    void Slash()
    {
        Instantiate(hitbox);
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
        inDimension = false;
        counter.ExitDimension();
    }
}
