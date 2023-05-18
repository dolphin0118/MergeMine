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
    private ItemObject previous_object;
    private ItemObject recent_object;
    public int previous_level;
    public int recent_level;
    public bool isRespawn;

    void Awake() {
        if(this.transform.childCount == 0) spawn();
        previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
        previous_level = previous_object.item_Level;
        recent_level = 0;
        isRespawn = true;
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
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
                previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
                previous_level = previous_object.item_Level;
                isRespawn = true;
            }
            else if(this.transform.childCount == 1) {
                previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
                recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
                if(previous_object.item_Level == recent_object.item_Level) Combine(eventData);
                else Swap(eventData);
            }
        }
    }

    public void Combine(PointerEventData eventData) {
        previous_level = previous_object.item_Level + 1;
        previous_object.item_Level = previous_level;
        DragUI recent_parent = eventData.pointerDrag.transform.gameObject.GetComponent<DragUI>();
        recent_parent.previousParent.GetComponent<DropUI>().isRespawn = false;
        Destroy(eventData.pointerDrag.transform.gameObject);
    }

    public void Swap(PointerEventData eventData) {
        previous_level = recent_object.item_Level;
        recent_level = previous_object.item_Level;
        previous_object.item_Level = previous_level;
        recent_object.item_Level = (int)recent_level;
    }

    public void spawn() { 
        GameObject Pick_prefab = Instantiate(Item_prefab, transform.position, Quaternion.identity);
        Pick_prefab.GetComponent<ItemObject>().item_Level = previous_level;
        Pick_prefab.transform.SetParent(transform);
        previous_object = Pick_prefab.transform.gameObject.GetComponent<ItemObject>();
        Pick_prefab.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        Pick_prefab.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    public void Respawn() {
        if(isRespawn) spawn();
    }
}
