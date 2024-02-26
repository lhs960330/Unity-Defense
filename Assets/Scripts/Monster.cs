using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    //���Ͱ� �������� �����ϰ� �������� ���������� ü���� ��� ��������.
    [SerializeField] NavMeshAgent agent;
    public float hp;
    public UnityEvent OnEndPontArrvied;
    //[SerializeField] Image hpBar;

    private void Update()
    {
        CheckEndPoint();
        //  HpBar();
    }
    /*   private void HpBar()
       {
           float aa = 4 / hp;
           aa = hpBar.rectTransform.rect.width;
       }*/
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
