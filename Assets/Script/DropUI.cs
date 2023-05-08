using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;
    public GameObject Item_prefab;
    public ItemObject previous_object = null;
    private ItemObject recent_object;
    private ItemObject temp_object;
    
    void Awake() {
        if(this.transform.childCount > 0) {
            previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
            temp_object = previous_object;
        }
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && previous_object == null) Respawn();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            if(this.transform.childCount == 0) {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                previous_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
            }
            else if(this.transform.childCount == 1) {
                Combine(eventData);
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }
        }
    }

    public void Combine(PointerEventData eventData) {
        recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
        if(previous_object == null) previous_object = recent_object;
        else if(previous_object.item_Level == recent_object.item_Level){
            previous_object.item_Level+=1;
            temp_object = previous_object;
            Destroy(eventData.pointerDrag.transform.gameObject);
        }
    }

    public void Respawn() {
        GameObject Pick_Clone = GameObject.FindWithTag("Pick_Parent");
        if(Pick_Clone.transform.childCount == 0 && this.transform.childCount == 0) {
            GameObject Pick_prefab = Instantiate(Item_prefab, transform.position, Quaternion.identity);
            Pick_prefab.transform.SetParent(transform);
            Pick_prefab.GetComponent<ItemObject>().item_Level = temp_object.item_Level;
            previous_object = Pick_prefab.transform.gameObject.GetComponent<ItemObject>();
            Pick_prefab.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            Pick_prefab.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
        }
    }
}
