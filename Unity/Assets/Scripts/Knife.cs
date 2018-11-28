using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
    public float rotateSpeed;
    public float speed;
    public GameObject item;
    public int knifeNum;

	public void Init (Vector2 dir, GameObject item, int num) {
        GetComponent<Rigidbody2D>().velocity = dir * speed;
        this.item = item;
        knifeNum = num;
        Destroy(gameObject, 10);
	}
	
	void Update () {
        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Player")&&other.gameObject.GetComponent<DeadItem>()==null&&other.gameObject.GetComponent<Knife>()==null) {
            GameObject pickup = Instantiate(item,transform.position,Quaternion.identity,PlayerController.player.entities.transform);
            pickup.GetComponent<DeadItem>().SetKnifeNum(knifeNum);
            Destroy(gameObject);
        }
    }
}
