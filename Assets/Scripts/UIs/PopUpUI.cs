using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : BaseUI
{
   // 일시정지 UI
   public void Close()
    {
        Manager.UI.ClosePopUpUI();
    }
}
