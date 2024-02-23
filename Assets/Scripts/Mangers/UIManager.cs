using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystemPrefab;

    private void Awake()
    {
        EnsurEventSystem();
    }
    // 이벤트 시스템이 없었을때 생성해주고 있으면 안하고
    public void EnsurEventSystem()
    {

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if(eventSystem == null)
        {
            Instantiate(eventSystemPrefab);
        }
    }
}
