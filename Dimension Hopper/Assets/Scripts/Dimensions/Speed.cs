using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] public EnemyData Rectangle;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject rectangle;
    public double newHealth;
    public Wakizashi_Counter counter;
    public double cooldown;

    public PlayerAttributes player;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        counter = new Wakizashi_Counter();
        rectangle = new GameObject();
        rectangle.AddComponent(typeof(EnemyData));
    }
    public void enterDimension(PlayerAttributes player)
    {
        this.player = player;
        this.player.dimensionChangeSpeed(newHealth);
    }
    // Update is called once per frame
    void Update()
    {
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
    void spawnNew()
    {
        Instantiate(rectangle);
    }
    public void isAttacked(double damage)
    {
        if (counter.counter())
        {
            //say successful counter
        }
        else
        {
            player.changeHealth(damage);
            if (player.getAlive() == false)
            {
                exitDimension();
                //end the game
            }
        }
    }

    public PlayerAttributes exitDimension()
    {
        //end the instance of Wakizashi Counter
        return player;
    }
}
