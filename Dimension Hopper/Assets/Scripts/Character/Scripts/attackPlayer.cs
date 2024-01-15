using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour
{
    public Collider EnemyHitbox;

    public double damage;

    public double attackWindup;

    public double timeToAttack;

    public int currentDimension;

    public Durability durabilityDimension;

    public Speed speedDimension;

    public TimeDimension timeDimension;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHitbox = GetComponent<Collider>();
        
    }

    void fillInData(EnemyData enemy, Durability durability, Speed speed, TimeDimension time)
    {
        this.damage = enemy.damage;
        this.attackWindup = enemy.attackWindup;
        durabilityDimension = durability;
        speedDimension = speed;
        timeDimension = time;
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
        switch (currentDimension)
        {
            case 1:
                durabilityDimension.isAttacked(damage);
                break;
            case 2:
                speedDimension.isAttacked(damage);
                break;
            case 3:
                timeDimension.isAttacked(damage);
                break;
        }
    }
    void newDimension(int dimensionNum)
    {
        currentDimension = dimensionNum;
    }
}
