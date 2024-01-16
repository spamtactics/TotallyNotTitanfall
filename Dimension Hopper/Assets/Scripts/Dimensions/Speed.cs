using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] public EnemyData Rectangle;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject rectangle;
    public attackPlayer attackPlayer;
    public double newHealth;
    public Wakizashi_Counter counter;
    public double cooldown;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        counter = new Wakizashi_Counter();
        rectangle = new GameObject();
        rectangle.AddComponent(typeof(EnemyData));
    }
    public PlayerAttributes enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeSpeed(newHealth);
        attackPlayer.fillInData(Rectangle, player);
        rectangle.AddComponent(typeof(attackPlayer));
        return player;
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
        //end the instance of Wakizashi Counter
    }
}
