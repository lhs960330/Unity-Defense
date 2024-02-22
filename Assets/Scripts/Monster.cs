using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    //���Ͱ� �������� �����ϰ� �������� ���������� ü���� ��� ��������.
    [SerializeField] NavMeshAgent agent;
    public int hp;
    public UnityEvent OnEndPontArrvied;

    private void Update()
    {
        CheckEndPoint();
    }
    public void SetDestination(Transform endPoint)   
    {
        agent.destination = endPoint.position;
    }
   private void CheckEndPoint()
    {
        // sqrMagnitude�� �뷫������ �Ҷ� ���
        if ((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            //Debug.Log("���Ͱ� ������ �÷��̾� ����");
            OnEndPontArrvied?.Invoke();
            Destroy(gameObject);
        }
    }
}
