using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollView : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public ScrollRect parentScrollRect;
    private ScrollRect _scrollRect;
    private bool _isDraggingParent = false;

    void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            _scrollRect.OnBeginDrag(eventData);
        }
        else
        {
            if (_scrollRect.verticalNormalizedPosition <= 0 && eventData.delta.y > 0)
            {
                parentScrollRect.OnBeginDrag(eventData);
                _isDraggingParent = true;
            }
            else if (_scrollRect.verticalNormalizedPosition >= 1 && eventData.delta.y < 0)
            {
                parentScrollRect.OnBeginDrag(eventData);
                _isDraggingParent = true;
            }
            else
            {
                _scrollRect.OnBeginDrag(eventData);
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDraggingParent)
        {
            parentScrollRect.OnDrag(eventData);
        }
        else
        {
            _scrollRect.OnDrag(eventData);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isDraggingParent)
        {
            parentScrollRect.OnEndDrag(eventData);
            _isDraggingParent = false;
        }
        else
        {
            _scrollRect.OnEndDrag(eventData);
        }
    }
}
