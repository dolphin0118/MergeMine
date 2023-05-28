using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public GameObject GameClear_Scene;
    public bool isGameClear = false;
    void Awake() {
        if (instance == null) { instance = this; }
        else Destroy(this.gameObject);
        GameClear_Scene.SetActive(false);
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update() {
        if(isGameClear) GameClear_Scene.SetActive(true);
    }
}
