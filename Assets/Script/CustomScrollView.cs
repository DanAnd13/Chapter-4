using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public ScrollRect parentScrollRect;
    private ScrollRect scrollRect;
    private bool isDraggingParent = false;

    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Determine whether to pass the drag event to the parent ScrollRect
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            // Horizontal scroll - handled by the child ScrollView
            scrollRect.OnBeginDrag(eventData);
        }
        else
        {
            // Vertical scroll - determine if the parent should scroll
            if (scrollRect.verticalNormalizedPosition <= 0 && eventData.delta.y > 0)
            {
                // The child ScrollView is at the bottom and the user is dragging up
                parentScrollRect.OnBeginDrag(eventData);
                isDraggingParent = true;
            }
            else if (scrollRect.verticalNormalizedPosition >= 1 && eventData.delta.y < 0)
            {
                // The child ScrollView is at the top and the user is dragging down
                parentScrollRect.OnBeginDrag(eventData);
                isDraggingParent = true;
            }
            else
            {
                // Allow child ScrollView to handle the scroll
                scrollRect.OnBeginDrag(eventData);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggingParent)
        {
            // Pass the drag event to the parent ScrollView
            parentScrollRect.OnDrag(eventData);
        }
        else
        {
            // Allow child ScrollView to handle the scroll
            scrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggingParent)
        {
            // Pass the end drag event to the parent ScrollView
            parentScrollRect.OnEndDrag(eventData);
            isDraggingParent = false;
        }
        else
        {
            // Allow child ScrollView to handle the scroll
            scrollRect.OnEndDrag(eventData);
        }
    }
}
