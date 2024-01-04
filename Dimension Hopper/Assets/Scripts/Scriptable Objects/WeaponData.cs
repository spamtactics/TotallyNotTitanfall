using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="MeleeWeapon", menuName="Weapon/Melee")]
public class WeaponData : ScriptableObject {
    [Header("Info")]
    public string weaponName;
    public double damage;
    public double attackFrequency;
    public double weaponrange;
}
