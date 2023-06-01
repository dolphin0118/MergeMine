using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldManager : MonoBehaviour {
    public static GoldManager instance = null;
    public TextMeshProUGUI gold_text;
    public int Gold = 0;
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
        gold_text = GameObject.FindWithTag("Gold").GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        gold_text.text = "Gold \n\n" + Gold.ToString();
    }
}
