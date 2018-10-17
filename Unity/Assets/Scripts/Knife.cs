﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public float rotateSpeed;
    public float speed;

	public void Init (Vector2 dir) {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
        Destroy(gameObject, 10);
	}
	
	void Update () {
        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime);
	}
}
