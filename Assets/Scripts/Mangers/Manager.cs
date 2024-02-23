using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Inst { get { return instance; } }

    [SerializeField] UIManager uiManager;
    public static UIManager UI { get { return instance.uiManager; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // 파괴되지 않는 오브젝트
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
