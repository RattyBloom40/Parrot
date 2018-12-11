using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool canChangeKnife = true;
    public float knifeChangeTime = 1f;
    public bool hasKnives = true;

    public Text HUD;

    public Weapon[] knives;
    public Weapon[] guns;

    public GameObject[] knivesObjects;//all the throwable knives
    public GameObject[] gunsObjects;//all of the guns

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
        curWeaponList = knives;
        m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
        PlayerController.player.inventory = this;
    }
    void Update() //takes in input to switch the current weapon
    {
        //Code that tells you which weapon and how much ammo
        if(curWeaponList==knives)
            HUD.text = (knives[knifeIndex].name+": "+knives[knifeIndex].ammo);
        //

        //Code that sets the png to the next available guns if the ammo of the current png = 0
        //
        //
        if (curWeaponList == knives && knives[knifeIndex].getAmmo() == 0||hasKnives==false)
        {
            //Debug.Log("in the if");
            for (int cur = 0; cur < knives.Length; cur++)
            {
                if (knives[cur].getAmmo() == 0 && cur == knives.Length - 1)
                {
                    hasKnives = false;
                    break;
                }
                else if (knives[cur].getAmmo() == 0)
                    continue;
                else if (knives[cur].getAmmo() > 0)
                {
                    knifeIndex = cur;
                    hasKnives = true;
                    Debug.Log(knifeIndex);
                    m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
                    break;
                }
            }
        }
        //
        //
        //
        aimDir = PlayerController.player.aimDir;
        if (Input.GetButtonDown("WeaponTypeSwitch")) //flips between which list you will be displaying and using as the current weapon using q key
        {
            if (curWeaponList == knives)
            {
                curWeaponList = guns; //Debug.Log("switched to guns");
                m_SpriteRenderer.sprite = gunsSprites[gunIndex];
            }
            else if (curWeaponList == guns)
            {
                curWeaponList = knives;
                m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
            }
            //Debug.Log("Switched lists");
            for (int cur = 0; cur < knivesObjects.Length; cur++)
            {
                if (knives[cur].getAmmo() > 0)
                {
                    break;
                }
                else if (cur == knivesObjects.Length - 1 && knives[cur].getAmmo() == 0)
                {
                    hasKnives = false;
                }
            }
        }

        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) >= .01f && canChangeKnife)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0) //Scrolls through the current weapon list moving UP
            {
                if (curWeaponList == knives)
                {
                    if (knifeIndex < knives.Length - 1&&knives[knifeIndex+1].getAmmo()!=0)
                        knifeIndex++;
                    else if (knifeIndex >= knives.Length - 1&& knives[0].getAmmo() != 0)
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
                    if (knifeIndex > 0 && knives[knifeIndex - 1].getAmmo() != 0)
                        knifeIndex--;
                    else if (knifeIndex <= 0 && knives[knives.Length-1].getAmmo() != 0)
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
        }
        if (Input.GetButtonDown("Fire1")) //uses left mouse click to fire the weapon
        {
            //Debug.Log(hasKnives);
            if ((curWeaponList == knives && knives[knifeIndex].getAmmo() == 0) || hasKnives == false)
            {
                //Debug.Log("in the if");
                for (int cur = 0; cur < knives.Length; cur++)
                {
                    if (knives[cur].getAmmo() == 0 && cur == knives.Length - 1)
                    {
                        hasKnives = false;
                        break;
                    }
                    else if (knives[cur].getAmmo() == 0)
                        continue;
                    else if (knives[cur].getAmmo() > 0)
                    {
                        knifeIndex = cur;
                        hasKnives = true;
                        Debug.Log(knifeIndex);
                        m_SpriteRenderer.sprite = knivesSprites[knifeIndex];
                    }
                }
            }
            if (curWeaponList == knives && hasKnives == true)
            {
                //Debug.Log("in the method");
                if (knives[knifeIndex].getAmmo() >= 1)
                {
                    //Debug.Log("Cool Bios");
                    knives[knifeIndex].setAmmo(knives[knifeIndex].getAmmo() - 1);
                    Instantiate(knivesObjects[knifeIndex], transform.position, Quaternion.identity, PlayerController.player.entities.transform).GetComponent<KnifeInThrow>().Init(PlayerController.player.aimDir, deadItems[knifeIndex], knifeIndex);
                }
                if (knives[knifeIndex].getAmmo() == 0)
                {
                    //Debug.Log("I am stupid"+" on knife "+knifeIndex+" "+knives[knifeIndex].name+knives[knifeIndex].ammo);
                }
            }
            if(curWeaponList == guns)
            {
                Debug.Log("Shooting gun");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, aimDir, 100, LayerMask.GetMask("Default"));
                if (hit.collider == null)
                    Debug.Log("Hit nothing");
                if (hit.collider.gameObject.GetComponent<EnemyController>() != null)
                    Debug.Log("Hit enemy");
                else if(hit.collider!=null)
                    Debug.Log("Hit " + hit.collider.gameObject.name);
                Debug.Log(aimDir.ToString());
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

    IEnumerator waitForKnifeChange()
    {
        yield return new WaitForSeconds(knifeChangeTime);
        canChangeKnife = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, aimDir));
    }
}