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
    private ItemObject previous_object = null;
    private ItemObject recent_object;
    
    void Awake() {
        if(this.transform.childCount > 0) {
            previous_object = transform.GetChild(0).gameObject.GetComponent<ItemObject>();
        }
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
                previous_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
            }
            else if(this.transform.childCount == 1) {
                Combine(eventData);
            }
        }
    }

    public void Combine(PointerEventData eventData) {
        recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
        if(previous_object == null) {
            previous_object = recent_object;
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
        else if(previous_object.item_Level == recent_object.item_Level){
            previous_object.item_Level += 1;
            recent_object.item_Level = int.MaxValue;
            Destroy(eventData.pointerDrag.transform.gameObject);
        }
        else return;

    }

    public void Respawn() {
        GameObject Pick_Clone = GameObject.FindWithTag("Pick_Parent");
        if(Pick_Clone.transform.childCount == 0 && this.transform.childCount == 0 && previous_object.item_Level < int.MaxValue) {
            GameObject Pick_prefab = Instantiate(Item_prefab, transform.position, Quaternion.identity);
            Pick_prefab.transform.SetParent(transform);
            Pick_prefab.GetComponent<ItemObject>().item_Level = previous_object.item_Level;

            previous_object = Pick_prefab.transform.gameObject.GetComponent<ItemObject>();
            Pick_prefab.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            Pick_prefab.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
        }
    }
    public void spawn() {
        GameObject Pick_prefab = Instantiate(Item_prefab, transform.position, Quaternion.identity);
            Pick_prefab.transform.SetParent(transform);
            previous_object = Pick_prefab.transform.gameObject.GetComponent<ItemObject>();
            Pick_prefab.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
            Pick_prefab.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }
}
