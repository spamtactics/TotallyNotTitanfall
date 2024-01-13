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
	public bool immune=false;
    public double cooldown;
    // Attack speed increase is hard coded onto the unique weapon
    // Start is called before the first frame update
    void Start()
    {
        counter = new Wakizashi_Counter();
        rectangle = new GameObject();
        rectangle.AddComponent(typeof(EnemyData));
    }
    void enterDimension(PlayerAttributes player)
    {
        player.dimensionChangeSpeed(newHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (counter.TriggerAbility())
            {
                immune = true;
                //print successful ability
            }
            else
            {
                cooldown = counter.getCooldown();
                //print cooldown
            }
        }
        
    }

    void isAttacked(PlayerAttributes player, double damage)
    {
        if (counter.counter())
        {
            //say successful counter
        }
        else
        {
            player.changeHealth(damage);
        }
    }
}
