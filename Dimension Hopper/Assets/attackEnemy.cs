using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    private double damage;
    private EnemyData targetData;
    public double enemyHealth;
    public double attackDuration=0.1;
    // Start is called before the first frame update
    public void Start()
    {
        // useless
    }

    public void updateDamage(double damage)
    {
        this.damage = damage;
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision enemy)
    {
        targetData=enemy.gameObject.GetComponent<EnemyData>();
        enemyHealth = targetData.health;
        enemyHealth = enemyHealth - damage;
        if (enemyHealth < 0)
        {
            Destroy(enemy.gameObject);
        }
        else
        {
            targetData.health = enemyHealth;
        }
    }
    private void Update()
    {
        attackDuration = attackDuration - Time.deltaTime;
        if (attackDuration < 0.0)
        {
            Destroy(this.gameObject);
        }
    }
}
