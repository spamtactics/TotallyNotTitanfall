using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public bool inDimension;
    [SerializeField] public EnemyData Rectangle;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject rectangle;
    public attackPlayer attackPlayer;
    public double newHealth;
    public Wakizashi_Counter counter;
    public double cooldown;

    [SerializeField] public WeaponData Wakizashi;

    public double attackFrequency;

    public double attackCooldown;

    public GameObject hitbox;

    public attackEnemy slash;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        rectangle = new GameObject();
        //adding the Enemydata
        rectangle.AddComponent(typeof(EnemyData));
        EnemyData data =rectangle.GetComponent<EnemyData>();
        data = Rectangle;
        rectangle.AddComponent(typeof(EnemyNavigation));
        //adding the attackPlayer script
        rectangle.AddComponent(typeof(attackPlayer));
        attackPlayer=rectangle.GetComponent<attackPlayer>();
        attackPlayer.fillInData(Rectangle);
        counter = new Wakizashi_Counter();
        hitbox.AddComponent(typeof(attackEnemy));
        slash = hitbox.GetComponent<attackEnemy>();
        slash.updateDamage(Wakizashi.damage);
    }
    public PlayerAttributes enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeSpeed(newHealth);
        counter.EnterDimension();
        attackCooldown = 0;
        inDimension = true;
        return player;
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
