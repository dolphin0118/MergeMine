using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [CreateAssetMenu]
public class Block : ScriptableObject{
    public int Block_hardness;
    public Sprite Block_image;
    public string item_name;
    public GameObject item_drop;
}
