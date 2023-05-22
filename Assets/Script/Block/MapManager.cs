using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {
    public static MapManager instance = null;
    private GameObject Block_Map;
    public int width = 6;
    public int height = -7;
    public int height_value = 5;
    public GameObject block;
    
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
        Block_Map = GameObject.FindWithTag("Block_Parent");
        Create();    
    }

    void Create() {
        for(int i = -width/2; i <= width/2; i++) {
            for(int j = height; j <= height + height_value; j++) {
                GameObject Block_Create = Instantiate(block, new Vector2(i, j), Quaternion.identity);
                Block_Create.transform.parent = Block_Map.transform; 
            }   
        }
    }

    public void ReCreate() {
        int childcount = Block_Map.transform.childCount;
        for(int i = childcount - 1; i >= 0; i--) {
            Destroy(Block_Map.transform.GetChild(i).gameObject);
        }
        Create();
    }
}
