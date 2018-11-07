﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour
{

    //************************************* Singleton ******************************************//

    public static ThrowKnife instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.Log("Error: 2 ThrowKnifes active");
    }

    //************************************* Singleton ******************************************//

    public float speed; //store the player's movement speed
    private Rigidbody2D rb2d; //store game object for physics
    float mouseX;
    float mouseY;
    float playerX;
    float playerY;
    public GameObject[] knives;
    public GameObject[] thrownObject;
    public GameObject[] items;
    public int[] inventoryStatus;
    public GameObject currentKnife;
    public bool canChangeKnife = true;
    public float knifeChangeTime = 1f;

    void Update()
    {
        if(currentKnife==null)
            for(int cur=0;cur<knives.Length;cur++)
            {
                if(inventoryStatus[cur]>=1)
                {
                    Debug.Log("knife = null");
                    currentKnife = knives[cur];
                    currentKnife.SetActive(true);
                    break;
                }
            }
        //	Knife throwing animation below
        if (Input.GetButtonDown("Fire1"))
        {
            for (int cur = 0; cur < 9; cur++)
            {
                if (knives[cur] == currentKnife)
                {
                    currentKnife.SetActive(false);
                    Instantiate(thrownObject[cur], transform.position, Quaternion.identity, PlayerController.player.entities.transform).GetComponent<Knife>().Init(PlayerController.player.aimDir, items[cur],cur);
                    inventoryStatus[cur] -= 1;
                    if (inventoryStatus[cur] >= 1)
                    {
                        currentKnife.SetActive(true);
                        break;
                    }
                    int target;
                    int round = 0;
                    do
                    {
                        round++;
                        if (cur-round >= 0)
                        {
                            target = cur - round;
                        }
                        else
                        {
                            target = knives.Length - round+cur;
                        }
                        if(round>=knives.Length)
                        {
                            target = -1;
                            break;
                        }
                    } while (inventoryStatus[target] == 0);
                    if (target == -1)
                    { 
                        currentKnife = null;
                    }
                    else
                    {
                        currentKnife = knives[target];
                        currentKnife.SetActive(true);
                    }
                    break;
                }
            }
        }
        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) >= .01f && canChangeKnife)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                for (int cur = 0; cur < knives.Length; cur++)
                {
                    if (knives[cur]==currentKnife)
                    {
                        currentKnife.SetActive(false);
                        if (cur < knives.Length - 1)
                        {
                            Debug.Log("lees than length");
                            Debug.Log(cur);
                            currentKnife = knives[cur + 1];
                            currentKnife.SetActive(true);
                            break;
                        }
                        else if (cur == knives.Length - 1)
                        {
                            //Debug.Log("equal to length");
                            //Debug.Log(cur);
                            currentKnife = knives[0];
                        }
                        currentKnife.SetActive(true);
                    }
                }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                for (int cur = 0; cur < knives.Length; cur++)
                {
                    //Debug.Log(cur);
                    if (knives[cur] == currentKnife)
                    {
                        currentKnife.SetActive(false);
                        if (cur > 0)
                        {
                            currentKnife = knives[cur - 1];
                        }
                        else if (cur == 0)
                        {
                            currentKnife = knives[knives.Length - 1];
                        }
                        currentKnife.SetActive(true);
                    }
                }
        }
        canChangeKnife = false;
        StartCoroutine(waitForKnifeChange());
    }
        
    IEnumerator waitForKnifeChange()
    {
        yield return new WaitForSeconds(knifeChangeTime);
        canChangeKnife = true;
    }
}
