using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake(); // 바인딩 과정 진행에 필요

        texts["Tltle"].text = "Title";
        buttons["NextButton"].onClick.AddListener(Jump) ;
    }
    public void Jump()
    {
        Debug.Log("Jump");
    }
}
