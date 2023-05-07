using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 [CreateAssetMenu]
 [SerializeField]
public class Item : ScriptableObject{
    public int item_Level;
    public Sprite item_image;
    public GameObject item_drop;
    public int item_hardness;
    public int item_durability;
}
