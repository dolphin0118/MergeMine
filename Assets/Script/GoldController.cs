using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour {
    private float speed = 1f;
    private float alpha_value = 0.1f;
    private Color alpha;
    private TextMesh text;
    private Vector3 pos;
    void Awake() {
        text = GetComponent<TextMesh>();
        alpha = Color.yellow;
        StartCoroutine(Fade_out());
    }

    void Update() {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    IEnumerator Fade_out(){
        while(text.color.a > 0) {
            alpha.a -= alpha_value;
            text.color = alpha;
            yield return new WaitForSeconds(0.3f);
        }
        Text_Destroy();
        yield return null;
        
    }
    void Text_Destroy() {
        Destroy(gameObject);
    }

}
