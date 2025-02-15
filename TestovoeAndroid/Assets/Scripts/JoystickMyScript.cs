using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMyScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform background;
    public RectTransform handle;
    private Vector2 inputVector = Vector2.zero;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position - (Vector2)background.position;
        inputVector = pos.magnitude > background.sizeDelta.x / 2f ? pos.normalized : pos / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = inputVector * (background.sizeDelta.x / 2f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;
}
