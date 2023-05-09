using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour {
    private int Slot_count = 0;
    public ItemObject[] Items;
    void Awake() {
        Slot_count = this.transform.childCount;
        Items = new ItemObject[Slot_count];
    }

    void Update(){
        Drop_check();
        Drop_All();
    }

    bool Slot_check() {
        for (int i = 0; i < Slot_count; i++) {
            if (this.transform.GetChild(i).transform.childCount == 1) return true;
        }
        return false;
    }
    void Drop_check() {
        for (int i = 0; i < Slot_count; i++) {
            if(this.transform.GetChild(i).childCount == 1) {
                Items[i] = this.transform.GetChild(i).GetChild(0).GetComponent<ItemObject>();
            }
            else Items[i] = null;
        }
    }
    void Drop_All() {
        if(Input.GetKeyDown(KeyCode.Space) && Slot_check()) {
            for (int i = 0; i < Slot_count; i++) if(Items[i] != null) Items[i].Drop();
        }
    }
}
