using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour {
    private int Slot_count = 0;
    private ItemObject[] Items;
    void Awake() {
        Slot_count = this.transform.childCount;
    }
    void Slot_check() {
        for(int i = 0; i < Slot_count; i++) {
            Items[i] = this.transform.GetChild(i).GetChild(0).gameObject.GetComponent<ItemObject>();
        }
    }
    void Update(){
        
    }

    void Drop_All() {
        if(Input.GetKeyDown(KeyCode.Space)) {

        }
    }
    void Drop_check() {

    }
}
