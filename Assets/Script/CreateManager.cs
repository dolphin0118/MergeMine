using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour {
    public static CreateManager instance = null;
    public int Gold = 0;
    void Awake() {
        if(instance == null) {instance = this;}
        else Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
