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
        // 얘하면 유도마냥 따라감 (선형보간) 
        transform.position = Vector3.Lerp(start.position, end.position, rate);
    }
}
