using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropItem : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Item _item;

    public GameObject item_drop = null;
    public Item item {
        get{return _item;}
        set{_item = value;}
    }
    public float Rotate_force = 200;
    public int? item_durability;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        Item_destroy();
        Item_rotate();
        Item_Set();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag =="Block") {
            if(item_durability == null) item_durability = _item.item_durability;
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            item_durability -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goal") {
            GameManager.instance.isGameClear = true;
        }
    }
    void Item_destroy() {
        if(item_durability <= 0) Destroy(gameObject); 
    }
    void Item_Set() {
        spriteRenderer.sprite = item.item_image;    
    }

    void Item_rotate() {
        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime * Rotate_force);
    }
}
