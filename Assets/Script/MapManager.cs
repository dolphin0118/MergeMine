using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {
    public int width = 6;
    public int height = -6;
    public int height_value = 5;
    public GameObject block;
    void Awake() {
        Create();
    }

    void Create() {
        for(int i = -width/2; i <= width/2; i++) {
            for(int j = height; j <= height + height_value; j++) {
                Instantiate(block, new Vector2(i, j), Quaternion.identity);
            }   
        }
    }

    void Update() {
        
    }
}
