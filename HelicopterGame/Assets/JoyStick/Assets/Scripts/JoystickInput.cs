using UnityEngine;
using UnityEngine.EventSystems;

public enum JoystickAxis
{
    None,
    Horizontal,
    Vertical
}

public class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 Axis { get; set; } = Vector2.zero;

    [SerializeField]
    private RectTransform handle;
    [SerializeField]
    private RectTransform background;
    [SerializeField, Range(0, 1)]
    private float deadzone = 0.25f;

    private Vector3 initialPosition = Vector3.zero;

    void Start()
    {
        initialPosition = handle.transform.position;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        // Calculate the axis of the input based ont he event data and the relative position to the background's centre
        Axis = new Vector2((_eventData.position.x - background.position.x) / ((background.rect.size.x - handle.rect.size.x) / 2), (_eventData.position.y - background.position.y) / ((background.rect.size.y - handle.rect.size.y) / 2));
        Axis = (Axis.magnitude > 1.0f) ? Axis.normalized : Axis;

        // Apply the axis position to the handle 
        handle.transform.position = new Vector2((Axis.x * ((background.rect.size.x - handle.rect.size.x) / 2)) + background.position.x, (Axis.y * ((background.rect.size.y - handle.rect.size.y) / 2)) + background.position.y);

        // Apply the deadzone effect after the handle has been placed into the correct position
        Axis = (Axis.magnitude < deadzone) ? Vector2.zero : Axis;
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        // We have let go so reset the axis and set the initial position
        Axis = new Vector2(0f, 0f);
        handle.transform.position = initialPosition;
    }

    public void OnPointerDown(PointerEventData _eventData) => OnDrag(_eventData);
    public void OnPointerUp(PointerEventData _eventData) => OnEndDrag(_eventData);
}
