using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public bool canChangeKnife = true;
    public float knifeChangeTime = 1f;

    public Weapon[] knives;
    public Weapon[] guns;

    public GameObject[] knivesObjects;//all the throwable knives
    public GameObject[] gunsObjects;//all of the guns

    public GameObject[] thrownKnives; //includes JUST knives
    public GameObject[] deadItems; //includes both GUNS and KNIVES

    public int knifeIndex = 0;
    public int gunIndex = 0;

    public Weapon[] curWeaponList;

    Rigidbody2D rb2D;
    public float floatHeight;
    public float liftForce;
    public float damping;
    public Vector2 aimDir;

    ///////////////////////////////////////
    public SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;
    float m_Red, m_Blue, m_Green;
    public Sprite[] knivesSprites;
    public Sprite[] gunsSprites;
    //////////////////////////////////////////////

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        aimDir = PlayerController.player.aimDir;
        curWeaponList = guns;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,aimDir);
        if (hit.collider.gameObject.GetComponent<EnemyController>() != null)
            Debug.Log("Hit enemy");
    }

    void Update() //takes in input to switch the current weapon
    {
        if (Input.GetAxis("WeaponTypeSwitch") > .1f) //flips between which list you will be displaying and using as the current weapon using q key
        {
            if (curWeaponList == knives)
            {
                curWeaponList = guns;Debug.Log("switched to guns");
                m_SpriteRenderer.sprite = gunsSprites[gunIndex];
            }
            else if (curWeaponList == guns)
            {
                curWeaponList = knives;
                m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
            }
            Debug.Log("Switched lists");
        }
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) >= .01f && canChangeKnife)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0) //Scrolls through the current weapon list moving UP
            {
                if (curWeaponList == knives)
                {
                    if (knifeIndex < knives.Length - 1)
                        knifeIndex++;
                    else if (knifeIndex >= knives.Length - 1)
                        knifeIndex = 0;
                    m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
                }
                else if (curWeaponList == guns)
                {
                    if (gunIndex < guns.Length - 1)
                        gunIndex++;
                    else
                        gunIndex = 0;
                    m_SpriteRenderer.sprite = gunsSprites[gunIndex];
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
                    m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
                }
                else if (curWeaponList == guns)
                {
                    if (gunIndex > 0)
                        gunIndex--;
                    else if (gunIndex <= 0)
                        gunIndex = guns.Length - 1;
                }
            }
            canChangeKnife = false;
            StartCoroutine(waitForKnifeChange());
        }if(knives[knifeIndex].getAmmo()!=0)
                knives[knifeIndex].setAmmo(knives[knifeIndex].getAmmo()-1);
            else
        if(Input.GetButtonDown("Fire1")) //uses left mouse click to fire the weapon
        {
            
            
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

    IEnumerator waitForKnifeChange()
    {
        yield return new WaitForSeconds(knifeChangeTime);
        canChangeKnife = true;
    }
}