using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Block_state : MonoBehaviour {
    public Block[] block_list;
    private Block block;
    public GameObject text;
    private SpriteRenderer spriteRenderer;
    private float block_hp = 0;
    private float Hp_percent;
    void Awake() {
        block = block_list[UnityEngine.Random.Range(0, block_list.Length)];
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = block.Block_image[0];
        Hp_percent = (float)Math.Round(block_hp/block.Block_hardness, 2);
    }

    void Update() {
        broken_degree();
        Destroy_block();
    }

    void broken_degree() {
        if(Hp_percent < 0.1) spriteRenderer.sprite = block.Block_image[0];
        else if(Hp_percent < 0.3) spriteRenderer.sprite = block.Block_image[1];
        else if(Hp_percent < 0.5) spriteRenderer.sprite = block.Block_image[2];
        else if(Hp_percent < 0.7) spriteRenderer.sprite = block.Block_image[3];
        else if(Hp_percent < 0.9) spriteRenderer.sprite = block.Block_image[4];
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Pick") {
            GameObject Pick = other.gameObject;
            Hp_percent += (float)Pick.GetComponent<DropItem>().item.item_hardness/100;
        }
    }
    void Destroy_block() {
        if(Hp_percent >= 1) {
            GameObject canvas = GameObject.FindWithTag("Canvas");
            text.GetComponent<TextMesh>().text = block.Block_gold.ToString() + " Gold";
            GameObject text_inst = Instantiate(text, transform.position, Quaternion.identity);
            text_inst.transform.SetParent(canvas.transform);
            Destroy(gameObject);

            GoldManager.instance.Gold += block.Block_gold;
            GoldManager.instance.Broken_block += 1;
        }
    }
}
