using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject target;
    public float stickyness;
	
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, stickyness);
	}
}
