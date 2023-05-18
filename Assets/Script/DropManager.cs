using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour {
    public static DropManager instance = null;
    private int Slot_count = 0;
    public ItemObject[] Items;
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
        Slot_count = this.transform.childCount;
        Items = new ItemObject[Slot_count];
    }

    void Update(){
        Item_check();
        Drop_All();
        Respawn_All();
    }

    bool Slot_check() {
        for (int i = 0; i < Slot_count; i++) {
            if (this.transform.GetChild(i).transform.childCount == 1) return false;
        }
        return true;
    }

    void Item_check() {
        for (int i = 0; i < Slot_count; i++) {
            if(this.transform.GetChild(i).childCount == 1) {
                Items[i] = this.transform.GetChild(i).GetChild(0).GetComponent<ItemObject>();
            }
            else Items[i] = null;
        }
    }

    void Drop_All() {
        if(Input.GetKeyDown(KeyCode.Space) && !Slot_check()) {
            for (int i = 0; i < Slot_count; i++) if(Items[i] != null) Items[i].Drop();
        }
    }

    void Respawn_All() {
        GameObject Pick_Clone = GameObject.FindWithTag("Pick_Parent");
        if(Input.GetKeyDown(KeyCode.Space) && Slot_check() && Pick_Clone.gameObject.transform.childCount == 0) {
            for(int i = 0; i < Slot_count; i++) this.transform.GetChild(i).GetComponent<DropUI>().Respawn();
        }
    }

    public void Create_Item() {
        if(!Slot_check()) {
            for (int i = 0; i < Slot_count; i++) {
                if(Items[i] == null) {
                    this.transform.GetChild(i).GetComponent<DropUI>().spawn();
                    break;
                }
            }
        }
    }
}
