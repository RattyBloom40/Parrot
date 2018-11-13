using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Weapon[] knives;
    public Weapon[] guns;

    public GameObject[] knivesObjects;
    public GameObject[] gunsObjects;

    public int knifeIndex = 0;
    public int gunIndex = 0;

    public Weapon[] curWeaponList;

    private void Update() //takes in input to switch the current weapon
    {
        if (Input.GetAxis("WeaponTypeSwitch") > .1f) //flips between which list you will be displaying and using as the current weapon
        {
            if (curWeaponList == knives)
            {
                curWeaponList = guns;
            }
            else if (curWeaponList == guns)
            {
                curWeaponList = knives;
            }
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0) //Scrolls through the current weapon list moving UP
        {
            if (curWeaponList == knives)
            {
                if (knifeIndex < knives.Length - 1)
                    knifeIndex++;
                else if (knifeIndex >= knives.Length - 1)
                    knifeIndex = 0;
            }
            else if (curWeaponList == guns)
            {
                if (gunIndex < guns.Length - 1)
                    gunIndex++;
                else
                    gunIndex = 0;
            }
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0) //Scrolls through the current weapon list moving DOWN
        {
            if (curWeaponList == knives)
            {
                if (knifeIndex > 0)
                    knifeIndex--;
                else if (knifeIndex <= 0)
                    knifeIndex = knives.Length - 1;
            }
            else if (curWeaponList == guns)
            {
                if (gunIndex > 0)
                    gunIndex--;
                else if (gunIndex <= 0)
                    gunIndex = guns.Length - 1;
            }
        }
    }
    private Weapon getCurWeapon() //gets the weapon on the index depending on which list is stored in curWeaponList
    {
        if (curWeaponList == knives)
        {
            return knives[knifeIndex];
        }
        else if (curWeaponList == guns)
        {
            return guns[gunIndex];
        }
        return null;
    }

    private Weapon[] getCurWeaponList() // returns the current weapon list (Mostly to know what to display)
    {
        return curWeaponList;
    }
}