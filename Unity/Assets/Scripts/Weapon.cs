using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Weapon : ScriptableObject {
    public string name;
    public int magSize;
    public float fireRate;
    public float weaponRange;
    public int ammo;
    
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

    public void setAmmo(int ammo)
    {
        this.ammo = ammo;
    }

    public int getAmmo()
    {
        return ammo;
    }

    public DamageType damageType;
    public Type type;
    public GameObject knifePrefab;
    public GameObject deadItem;
}