using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


 [Serializable]
public class ItemObject : MonoBehaviour {
    [SerializeField]
    private Item _item;
    private Image item_image;
    private GameObject item_drop = null;
    private GameObject Drop_item_parent = null;
    public Item item {
        get{return _item;}
        set{_item = value;}
    }
    public int item_Level = 0;
    void Start() {
        item_image = GetComponent<Image>();
        Drop_item_parent = GameObject.FindWithTag("Pick_Parent");
;    }

    void Update() {
        if(ItemDB.instance != null) {
            _item = ItemDB.instance.item_DB[item_Level];
            this.item_Level = _item.item_Level;
            this.item_image.sprite = _item.item_image;
            this.item_drop = _item.item_drop;
        }
        Drop();
    }

    void Drop() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector3 drop_pos = Camera.main.ScreenToWorldPoint(this.transform.position);
            drop_pos.z = 0;
            GameObject Drop_item = Instantiate(item_drop, drop_pos, Quaternion.identity);
            Drop_item.GetComponent<DropItem>().item = item;
            Drop_item.transform.parent = Drop_item_parent.transform;
            Destroy(gameObject);
        }
    }

}
