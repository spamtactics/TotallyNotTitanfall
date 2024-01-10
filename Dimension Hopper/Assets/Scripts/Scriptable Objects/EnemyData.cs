using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Enemy", menuName="Enemy", order=2)]
public class EnemyData : ScriptableObject {
    [Header("Info")]
    public string enemyName;
    public double damage;
    public double speed;
    public double spawnRate;
    public double hpRefund;
    public double attackWindup;
    public double attackRAnge;
}
