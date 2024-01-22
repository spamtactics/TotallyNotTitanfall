using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    public Collider EnemyHitbox;

    public double damage;

    public double attackWindup;

    public double timeToAttack;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHitbox = GetComponent<Collider>();
        
    }
    public void fillInData(EnemyData enemy)
    {
        damage = enemy.damage;
        attackWindup = enemy.attackWindup;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player = other.gameObject.GetComponent<Player>();
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
