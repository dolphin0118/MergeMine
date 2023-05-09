using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour {
    public static ItemDB instance = null;
    public List<Item> item_DB = new List<Item>();
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
    }
}
