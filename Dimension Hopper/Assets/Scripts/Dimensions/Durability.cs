using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Durability : MonoBehaviour
{
    public bool inDimension;
	// getting the enemy data
    [SerializeField] public EnemyData Triangle;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject triangle;
    public attackPlayer attackPlayer;
    //player attributes
    public double newHealth=10.0;
    public double newSpeed=0.75;
    public Shield_Guard guardAbility;
    public bool immune;
    
    public double cooldown;
    //weapon attributes
    [SerializeField] public WeaponData Shield;
    public double attackFrequency;
    public double attackCooldown;
    public GameObject Hitbox;
    public attackEnemy bash;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Triangle.spawnRate;
        timeToSpawn = spawnRate;
        triangle = new GameObject();
        //assigning the triangle data to it
        triangle.AddComponent(typeof(EnemyData));
        EnemyData data=triangle.GetComponent<EnemyData>();
        data = Triangle;
        triangle.AddComponent(typeof(EnemyNavigation));
        //assigning the attackPlayer script to it
        triangle.AddComponent(typeof(attackPlayer));
        attackPlayer=triangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(Triangle);
        guardAbility = new Shield_Guard();
        //getting weapon attributes
        attackFrequency = Shield.attackFrequency;
        Hitbox.AddComponent(typeof(attackEnemy));
        bash=Hitbox.GetComponent<attackEnemy>();
        bash.updateDamage(Shield.damage);
    }
    public Player enterDimension(Player player)
    {
        player.dimensionChangeDurability(newHealth, newSpeed);
        guardAbility.EnterDimension();
        attackCooldown = 0;
        inDimension = true;
        return player;
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
