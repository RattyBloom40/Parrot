﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour
{
    public float speed; //store the player's movement speed
    private Rigidbody2D rb2d; //store game object for physics
    float mouseX;
    float mouseY;
    float playerX;
    float playerY;
    public GameObject[] knives;
    public GameObject[] thrownObject;
    public GameObject currentKnife;
    public bool canChangeKnife = true;
    public float knifeChangeTime = 1f;

    void Update()
    {
        //Debug.Log("here");
        //knife throwing animation below
        if (Input.GetButtonDown("Fire1"))
        {
            for (int cur = 0; cur < 9; cur++)
            {
                if (knives[cur] == currentKnife)
                {
                    currentKnife.SetActive(false);

                    Instantiate(thrownObject[cur], transform.position, Quaternion.identity, PlayerController.player.entities.transform).GetComponent<Knife>().Init(PlayerController.player.aimDir);
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
                        Debug.Log("found the current knife");
                        currentKnife.SetActive(false);
                        if (cur < knives.Length - 1)
                        {
                            currentKnife = knives[cur + 1];
                        }
                        else if (cur == knives.Length - 1)
                        {
                            currentKnife = knives[0];
                        }
                        currentKnife.SetActive(true);
                    }
                }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                for (int cur = 0; cur < knives.Length; cur++)
                {
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
