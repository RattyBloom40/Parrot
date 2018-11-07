using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {
    private float reloadTime;
    private Weapon storedWeapon;

    private bool cooldown = false;

    public AttackManager(Weapon weapon)
    {
        storedWeapon = weapon;
		reloadTime = 1/weapon.fireRate;
    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void Attack(Vector2 aimDir)
    {
        if (!cooldown)
        {
            switch (storedWeapon.type)
            {
                case Weapon.Type.Melee:
                    //attack
                    cooldown = true;
                    StartCoroutine(Reload());
                    break;
                case Weapon.Type.Ranged:
                    switch (storedWeapon.damageType)
                    {
                        case Weapon.DamageType.Hitscan:
                            //attack
                            cooldown = true;
                            StartCoroutine(Reload());
                            break;
                        case Weapon.DamageType.Projectile:
                            //attack
                            cooldown = true;
                            StartCoroutine(Reload());
                            break;
                    }
                    break;
            }
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        cooldown = false;
    }
}
