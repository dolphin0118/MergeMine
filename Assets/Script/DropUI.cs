using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;
    private ItemObject previous_object = null;
    void Awake()
    {
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
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }
        }
    }

    public void Combine(PointerEventData eventData) {
        ItemObject recent_object;
        recent_object = eventData.pointerDrag.transform.gameObject.GetComponent<ItemObject>();
        if(previous_object == null) previous_object = recent_object;
        else if(previous_object.item_Level == recent_object.item_Level){
            previous_object.item_Level+=1;
            Destroy(eventData.pointerDrag.transform.gameObject);
        }
    }
}
