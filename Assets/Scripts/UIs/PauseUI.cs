using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : PopUpUI
{
    [SerializeField] SettingUI settingUIprefab;

    protected override void Awake()
    {
        base.Awake();

        buttons["SettingButton"].onClick.AddListener(Setting);
        buttons["CloseButton"].onClick.AddListener(Close);
    }
    public void Setting()
    {
        Manager.UI.ShowPopUpUI(settingUIprefab);
    }
    
}
