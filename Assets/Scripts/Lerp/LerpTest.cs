using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;

    [Range(0, 1)] public float rate;
    private void Update()
    {
        // ���ϸ� �������� ���� (��������) 
        transform.position = Vector3.Lerp(start.position, end.position, rate);
    }
}
