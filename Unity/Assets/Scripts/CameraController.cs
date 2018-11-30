using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject target;
    public float stickyness;
    public bool freeze;
	
	void FixedUpdate () {
        if (!freeze)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, stickyness);
        else
            transform.position = Vector3.Lerp(transform.position, target.transform.position, stickyness/2);
    }
}
