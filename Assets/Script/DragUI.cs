using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas; //UI의 최상단 Canvas;
    public Transform previousParent; //해당 오브젝트가 직전에 소속되어 있는 부모
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        previousParent = transform.parent;
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        previousParent = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(transform.parent == canvas) {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }
        else {
           previousParent.GetComponent<DropUI>().isspawn = false;
            previousParent.GetComponent<DropUI>().previous_level = 0;
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
