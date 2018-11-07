using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject {
    public string weaponName;
    public int magSize;
    public float fireRate;
    public float weaponRange;

    private bool cooldown = false;

    public enum DamageType
    {
        Projectile,
        Hitscan
    }

    public enum Type
    {
        Melee,
        Ranged
    }

    public DamageType damageType;
    public Type type;
}