using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadItem : MonoBehaviour {
    int knifeNum;
    public void SetKnifeNum(int num)
    {
        knifeNum = num;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            //ThrowKnife.instance.inventoryStatus[knifeNum]++;
            Destroy(gameObject);
        }
        
    }
}
