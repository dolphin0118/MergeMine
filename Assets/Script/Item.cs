using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 [CreateAssetMenu]
public class Item : ScriptableObject{
    public int item_Level;
    public Sprite item_image;
    public string item_name;
    public GameObject item_drop;
}
