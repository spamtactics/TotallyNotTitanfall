using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Dimension : MonoBehaviour
{
    public GameObject playerObject;
    public bool inDimension;
    // getting the enemy data
    public double spawnRate;
    public double timeToSpawn;
    public double enemyDamage;
    public double attackWindup;
    public GameObject sphere;
    public attackPlayer attackPlayer;
    public double cooldown;
    // Start is called before the first frame update
    public AdrenalineRush AdrenalineAbility;
    public Player player;
    public bool abilityActive;
    public double attackFrequency;
    public double attackCooldown;
    public double damage;
    public GameObject attackBox;
    public attackEnemy stab;
    void Start()
    {
        //getting the player
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
        //setting up the enemy
        timeToSpawn = spawnRate;
        sphere = new GameObject();
        sphere.AddComponent(typeof(EnemyNavigation));
        sphere.AddComponent(typeof(attackPlayer));
        attackPlayer = sphere.GetComponent<attackPlayer>();
        attackPlayer.fillInData(enemyDamage, attackWindup);
        AdrenalineAbility = playerObject.GetComponent<AdrenalineRush>();
        attackBox.AddComponent(typeof(attackEnemy));
        stab = attackBox.GetComponent<attackEnemy>();
        stab.updateDamage(damage);
    }
    public void enterDimension()
    {
        inDimension = true;
        Time.timeScale = 0.5f;
        AdrenalineAbility.EnterDimension();
        attackCooldown = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(inDimension){
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
                if (AdrenalineAbility.getActive() == false)
                {
                    player.endAdrenalineRush();
                    abilityActive = false;
                    //print ability ended
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
                    Stab();
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
    void spawnNew()
    {
        Instantiate(sphere);
    }
    void Stab()
    {
        Instantiate(attackBox);
    }
    public void exitDimension()
    {
        //end the instance of Adrenaline Rush
        if (abilityActive){
            player.endAdrenalineRush();
        }
        AdrenalineAbility.ExitDimension();
    }
}

