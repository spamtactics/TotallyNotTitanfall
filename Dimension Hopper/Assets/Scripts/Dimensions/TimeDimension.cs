using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDimension : MonoBehaviour
{
    public bool inDimension;
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
    [SerializeField] public WeaponData Sword;
    public double attackFrequency;
    public double attackCooldown;
    public GameObject hitbox;
    public attackEnemy stab;
    void Start()
    {
        spawnRate = Sphere.spawnRate;
        timeToSpawn = spawnRate;
        sphere = new GameObject();
        sphere.AddComponent(typeof(EnemyData));
        EnemyData data = sphere.GetComponent<EnemyData>();
        data = Sphere;
        sphere.AddComponent(typeof(EnemyNavigation));
        sphere.AddComponent(typeof(attackPlayer));
        attackPlayer = sphere.GetComponent<attackPlayer>();
        attackPlayer.fillInData(Sphere);
        AdrenalineAbility = new AdrenalineRush();
        attackFrequency = Sword.attackFrequency;
        hitbox.AddComponent(typeof(attackEnemy));
        stab = hitbox.GetComponent<attackEnemy>();
        stab.updateDamage(Sword.damage);
    }
    public void enterDimension(Player player)
    {
        inDimension = true;
        attackPlayer.fillInData(Sphere);
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
        Instantiate(hitbox);
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

