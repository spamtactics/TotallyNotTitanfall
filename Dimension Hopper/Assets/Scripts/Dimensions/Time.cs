using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDimension : MonoBehaviour
{
    // getting the enemy data
    [SerializeField] public EnemyData Sphere;
    public double spawnRate;
    public double timeToSpawn;
    public GameObject sphere;
    public attackPlayer attackPlayer;
    public double cooldown;
    // Start is called before the first frame update
    public AdrenalineRush AdrenalineAbility;
    public PlayerAttributes player;
    public bool abilityActive;
    void Start()
    {
        AdrenalineAbility = new AdrenalineRush();
        spawnRate = Sphere.spawnRate;
        timeToSpawn = spawnRate;
        //creating the triangle enemy
        sphere = new GameObject();
        sphere.AddComponent(typeof(EnemyData));
    }
    public void enterDimension(PlayerAttributes player)
    {
        attackPlayer.fillInData(Sphere, player);
        Time.timeScale = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        //check if attacked
        if (Input.GetKey(KeyCode.F))
        {
            if (AdrenalineAbility.TriggerAbility())
            {
                player.adrenalineRush();
                abilityActive = true;
                //print successful ability
            }
            else
            {
                cooldown = AdrenalineAbility.getCooldown();
                //print cooldown
            }
        }
        if (abilityActive)
        {
            if (AdrenalineAbility.getActive()==false)
            {
                player.endAdrenalineRush();
                abilityActive = false;
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
    void spawnNew()
    {
        Instantiate(sphere);
    }
    public PlayerAttributes exitDimension()
    {
        //end the instance of Adrenaline Rush
        if (abilityActive){
            player.endAdrenalineRush();
        }
        return player;
    }
}

