using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake(); // ���ε� ���� ���࿡ �ʿ�

        texts["Tltle"].text = "Title";
        buttons["NextButton"].onClick.AddListener(Jump) ;
    }
    public void Jump()
    {
        Debug.Log("Jump");
    }
}
