using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    public Collider EnemyHitbox;

    public double damage;

    public double attackWindup;

    public double timeToAttack;
    public PlayerAttributes player;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHitbox = GetComponent<Collider>();
        
    }
    public void fillInData(EnemyData enemy, PlayerAttributes player)
    {
        damage = enemy.damage;
        attackWindup = enemy.attackWindup;
        this.player = player;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            timeToAttack = attackWindup;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToAttack > 0)
        {
            timeToAttack = timeToAttack - Time.deltaTime;
        }
        else if (timeToAttack < 0)
        {
            triggerAttack();
            timeToAttack = 0;
        }
    }

    void triggerAttack()
    {
        player.changeHealth(damage);
    }
}
