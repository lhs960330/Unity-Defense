using UnityEngine;
using UnityEngine.EventSystems;


public class WindowUI : BaseUI, IDragHandler, IPointerDownHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.Translate(eventData.delta);
        //transform.position += (Vector3)eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Manager.UI.SelectWindowUI(this);
    }
    public void Close()
    {
        Manager.UI.CloseWindow(this);
    }
}
