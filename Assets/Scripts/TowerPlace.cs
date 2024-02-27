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
    // [SerializeField] GameObject tower;

    [SerializeField] BuildUI buildUI;

    [Header("Tower")]
    [SerializeField] TowerData archorTower;
    [SerializeField] TowerData canonTower;
    [SerializeField] TowerData mageTower;
    [SerializeField] TowerData barracksTower;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Click");
        // gameObject.isStatic = false;
        // Instantiate(tower, transform.position, transform.rotation);
        BuildUI ui = Manager.UI.ShowInGameUI(buildUI);
        ui.SetTarget(transform);
        ui.SetTowerPlace(this);

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

    public void BuildTower(string name)
    {
     /* if(name == "Archor")
        {
            gameObject.SetActive(false);
           Tower tower= Instantiate(archorTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }
      else if(name == "Cannon")
        {
            gameObject.SetActive(false) ;
            Tower tower = Instantiate(canonTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }
        else if (name == "Mage")
        {
            gameObject.SetActive(false);
            Tower tower = Instantiate(mageTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }
        else if (name == "Barracks")
        {
            gameObject.SetActive(false);
            Tower tower = Instantiate(barracksTower.prefab, transform.position, transform.rotation);
            tower.SetTowerPlace(this);
        }*/
    }
}
