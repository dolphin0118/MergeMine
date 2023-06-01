using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    public GameObject Item_prefab;
    public bool isspawn = false;
    private Image image;
    private RectTransform rect;
    private ItemObject previous_object = null;
    private ItemObject recent_object;
    public int previous_level;
    public int? recent_level;
    
    void Start() {
        init();
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }
    public void init() {
        if(isspawn) {
            spawn();
            previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
            previous_level = previous_object.item_Level;
            recent_level = previous_level;
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData) {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null) {
            isspawn = true;
            if(this.transform.childCount == 0) {
                recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                previous_level = recent_object.item_Level;
                recent_level = previous_level;          
            }
            else if(this.transform.childCount == 1) {
                recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
                previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
                if (previous_object.item_Level == recent_object.item_Level) Combine(eventData);
                else Swap(eventData);
                
            }
        }
    }

    public void Swap(PointerEventData eventData) {
        previous_level = recent_object.item_Level;
        recent_level = previous_object.item_Level;
        previous_object.item_Level = previous_level;
        recent_object.item_Level = (int)recent_level;
        return;
    }

    public void Combine(PointerEventData eventData) {
        previous_level = previous_object.item_Level + 1;
        previous_object.item_Level = previous_level;
        eventData.pointerDrag.transform.gameObject.GetComponent<DragUI>().previousParent.GetComponent<DropUI>().recent_level = null;
        Destroy(eventData.pointerDrag.transform.gameObject);
        return;
    }

    public void spawn() { 
        if(isspawn) {
            GameObject Pick_prefab = Instantiate(Item_prefab, transform.position, Quaternion.identity);
            Pick_prefab.GetComponent<ItemObject>().item_Level = previous_level;
            Pick_prefab.transform.SetParent(transform);
            previous_object = Pick_prefab.transform.gameObject.GetComponent<ItemObject>();
            Pick_prefab.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            Pick_prefab.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
        }
    }

    public void Respawn() {
        GameObject Pick_Clone = GameObject.FindWithTag("Pick_Parent");
        if (Pick_Clone.transform.childCount == 0 && this.transform.childCount == 0) {
            spawn();
        }
    }
}
