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

    public bool Attack(Vector2 dir)
    {
        if (!cooldown)
        {
            switch (type) //check melee vs ranged
            {
                case Type.Melee:
                    cooldown = true;
                    break;
                case Type.Ranged:
                    switch (damageType) //check hitscan vs projectile
                    {
                        case DamageType.Hitscan:
                            cooldown = true;
                            break;
                        case DamageType.Projectile:
                            cooldown = true;
                            break;
                    }
                    break;
            }
        }
        return true;
    }

    public void Reload() //in between attacks (cooldown counter)
    {

    }

    
}