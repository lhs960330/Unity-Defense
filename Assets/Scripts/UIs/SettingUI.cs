using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : PopUpUI
{
    [SerializeField] ShutCutUI shutCutUIPrefab;
    protected override void Awake()
    {
        base.Awake();

        buttons["ShotCutButton"].onClick.AddListener(ShowCut);
        buttons["CloseButton"].onClick.AddListener(Close);
    }

    public void ShowCut()
    {
        Manager.UI.ShowPopUpUI(shutCutUIPrefab);
    }
}
