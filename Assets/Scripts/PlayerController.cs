using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // �������� ���� �� ��ǥ�� �̵���Ű�� ��ũ��Ʈ
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform endPoint;
    [SerializeField] int attek;
    [SerializeField] int ragn;
    // endPoint�� �˾Ƽ� ���� ģ�� 
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
       // Debug.Log("�浹 ��");
        Monster monster = other.GetComponent<Monster>();
        if (monster != null)
        {
            //Debug.Log("���� �߰�");
            if ((transform.position - monster.transform.position).magnitude <= ragn)
            {
                //Debug.Log("����");
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
        // ī�޶󿡼� ���콺 �������� �������� ��� �޼���
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.red, 1f);
            MoveTo(hitInfo.point);
        }
    }

}
