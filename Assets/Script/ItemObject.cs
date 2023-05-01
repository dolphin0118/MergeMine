using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour {
    private Item _item;
    public int item_Level = 0;
    private string item_name;
    private Image item_image;
    public GameObject item_drop = null;
    public Item item {
        get{return _item;}
        set{_item = value;}
    }

    void Start() {
        item_image = GetComponent<Image>();
    }

    void Update()
    {
        if(ItemDB.instance != null) {
            _item = ItemDB.instance.item_DB[item_Level];
            this.item_Level = _item.item_Level;
            this.item_image.sprite = _item.item_image;
            this.item_name = _item.item_name;
            this.item_drop = _item.item_drop;
        }
        Drop();
    }

    void Drop() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Vector3 drop_item = Camera.main.ScreenToWorldPoint(this.transform.position);
            drop_item.z = 0;
            GameObject Drop_item = Instantiate(item_drop, drop_item, Quaternion.identity);
            Drop_item.GetComponent<SpriteRenderer>().sprite = item_image.sprite;
            Debug.Log("Drop Item");
        }
    }

}
