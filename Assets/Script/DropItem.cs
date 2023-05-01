using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
    public Sprite sprite;
    private Rigidbody2D rb;
    public float Rotate_force = 200;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        transform.Rotate(new Vector3(0, 0, 10) * Time.deltaTime * Rotate_force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag =="Block") {
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            
        }
    }
    void rotate_start() {

    }
}
