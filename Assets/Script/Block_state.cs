using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_state : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
    }

    void Update() {
        
    }
    void Destroy_block() {

    }
}
