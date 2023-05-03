using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Block_state : MonoBehaviour {
    public Block block;
    private SpriteRenderer spriteRenderer;
    private float block_hp = 0;
    private float Hp_percent;
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = block.Block_image[0];
    }

    void Update() {
        broken_degree();
        if(Hp_percent > 1) Destroy_block();
    }

    void broken_degree() {
        Hp_percent = (float)Math.Round(block_hp/block.Block_hardness, 2);
        if(Hp_percent < 0.1) spriteRenderer.sprite = block.Block_image[0];
        else if(Hp_percent < 0.3) spriteRenderer.sprite = block.Block_image[1];
        else if(Hp_percent < 0.5) spriteRenderer.sprite = block.Block_image[2];
        else if(Hp_percent < 0.7) spriteRenderer.sprite = block.Block_image[3];
        else if(Hp_percent < 0.9) spriteRenderer.sprite = block.Block_image[4];
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Pick") {
            GameObject Pick = other.gameObject;
            Debug.Log(Hp_percent);
        }
    }
    void Destroy_block() {
        Destroy(gameObject);
    }
}
