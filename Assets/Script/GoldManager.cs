using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GoldManager : MonoBehaviour {
    public static GoldManager instance = null;
    public TextMeshProUGUI gold_text;
    public TextMeshProUGUI score_text;
    public int Gold;
    public int Broken_block = 0;
    public int Respawn_count = 0;
    public int Create_pick = 0;

    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
        Gold = 300;
        gold_text = GameObject.FindWithTag("Gold").GetComponent<TextMeshProUGUI>();
        score_text = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update(){
        score_board();
        gold_text.text = "Gold \n" + Gold.ToString();
    }
    void score_board() {
        int total_score = Create_pick*100 + Broken_block * 100 + Respawn_count * -500 + Gold;
        score_text.text = "Create Picks: " + Create_pick.ToString() +" X 100\n"
                        + "Broken Blocks: " + Broken_block.ToString() +" X 100\n"
                        + "Respawn count: " + Respawn_count.ToString() +" X -500\n"
                        + "Remain Gold: " + Gold.ToString() + "\n\n"
                        + "Total Score: " + total_score;
    }
}
