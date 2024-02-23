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
    // �̺�Ʈ �ý����� �������� �������ְ� ������ ���ϰ�
    public void EnsurEventSystem()
    {

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if(eventSystem == null)
        {
            Instantiate(eventSystemPrefab);
        }
    }
}
