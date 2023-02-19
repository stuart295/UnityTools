using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// Handles events and callbacks for dragging UI elements around a canvas.
/// </summary>
public class DraggableUIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    

    public Transform ParentTransform { get => parentTransform; }
    public bool Draggable { get => draggable; set => draggable = value; }

    public UnityEvent<PointerEventData> onBeginDragEvent; 
    public UnityEvent<PointerEventData> onDragEvent; 
    public UnityEvent<PointerEventData> onEndDragEvent;

    public UnityEvent<PointerEventData> onBeginHover;
    public UnityEvent<PointerEventData> onEndHover;

    private RectTransform rect;
    private Transform parentTransform;
    private bool draggable = true;
    private CanvasGroup canvasGroup;
    private int siblingIdx = 0;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!Draggable) return;

        parentTransform = rect.parent;
        siblingIdx = transform.GetSiblingIndex();
        rect.SetParent(rect.root, true);
        canvasGroup.blocksRaycasts = false;
        onBeginDragEvent.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!Draggable) return;
        rect.position = eventData.position;
        onDragEvent.Invoke(eventData);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Draggable) return;
        rect.SetParent(parentTransform, true); ;
        rect.SetSiblingIndex(siblingIdx);
        rect.position = rect.parent.position;


        canvasGroup.blocksRaycasts = true;

        onEndDragEvent.Invoke(eventData);
    }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        onBeginHover.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onEndHover.Invoke(eventData);
    }

}
