using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RJoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public bool Pressed;

    void Start()
    {
        
    }

public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
