using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Enemy", menuName="Enemy",order=1)]
public class WeaponData : ScriptableObject {
    [Header("Info")]
    public string enemyName;
    public double damage;
    public double windup;
    public double attackrange;
    public double hpRefund;
    public double spawnRate;
    public double speed;
}

