using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerPlace : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerUpHandler,
    IPointerDownHandler,
    IPointerMoveHandler
{
    [SerializeField] Renderer render;
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor;
    [SerializeField] GameObject tower;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        Destroy(gameObject);
        Instantiate(tower, transform.position, transform.rotation);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        render.material.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        render.material.color = normalColor;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
       // Debug.Log("Move");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
    }
}
