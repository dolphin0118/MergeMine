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

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        Item_rotate();
        Item_Set();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag =="Block") {
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }

    void Item_Set() {
        spriteRenderer.sprite = item.item_image;    
    }

    void Item_rotate() {
        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime * Rotate_force);
    }
}
