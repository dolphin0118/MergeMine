using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldManager : MonoBehaviour {
    public static GoldManager instance = null;
    public TextMeshProUGUI gold_text;
    public TextMeshProUGUI score_text;
    public int Gold = 0;
    public int Broken_block = 0;
    public int Respawn_count = 0;
    public int Create_pick = 0;
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
        gold_text = GameObject.FindWithTag("Gold").GetComponent<TextMeshProUGUI>();
        score_text = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        score_board();
        gold_text.text = "Gold \n\n" + Gold.ToString();
    }
    void score_board() {
        score_text.text = "Create Picks: " + Create_pick.ToString() +'\n'
                        + "Broken Blocks: " + Broken_block.ToString() + '\n'
                        + "Respawn count: " + Respawn_count.ToString() + '\n'
                        + "Remain Gold: " + Gold.ToString() + "\n\n"
                        + "Total Score: ";
    }
}
