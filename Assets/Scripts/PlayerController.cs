using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // 레이져를 쏴서 그 좌표로 이동시키는 스크립트
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform endPoint;
    [SerializeField] int attek;
    [SerializeField] int ragn;
    // endPoint로 알아서 가는 친구 
    /* private void Start()
     {
         agent.destination = endPoint.transform.position;
     }*/
    /*private void Update()
    {
        if (monster != null)
        {
            if ((transform.position - monster.transform.position).magnitude <= ragn)
            {
                monster.hp -= attek;
            }
            if (monster.GetComponent<Monster>().hp < 0)
            {
                Destroy(monster);
            }
        }
    }*/
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("충돌 중");
        Monster monster = other.GetComponent<Monster>();
        if (monster != null)
        {
            //Debug.Log("몬스터 발견");
            if ((transform.position - monster.transform.position).magnitude <= ragn)
            {
                //Debug.Log("공격");
                monster.hp -= attek;
            }
            if (monster.hp < 0)
            {
                Destroy(monster.gameObject);
            }
        }
    }
    private void MoveTo(Vector3 point)
    {
        agent.destination = point;
    }

    private void OnRightClick(InputValue value)
    {
        // 카메라에서 마우스 방향으로 레이저를 쏘는 메서드
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 1f);
            MoveTo(hitInfo.point);
        }
    }

}
