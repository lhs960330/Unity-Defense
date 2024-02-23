using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerPlace : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] Renderer render;
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor;
    [SerializeField] GameObject tower;

    [SerializeField] InGameUI buildUI;
    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log("Click");
        gameObject.isStatic = false;
        Instantiate(tower, transform.position, transform.rotation);
        InGameUI ui = Manager.UI.ShowInGameUI(buildUI);
        ui.SetTarget(transform);
        ui.SetOffset(new Vector3(0, 150, 0));
        
    }

   
    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("Enter");
        render.material.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("Exit");
        render.material.color = normalColor;
    }

 
}
