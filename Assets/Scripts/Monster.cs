using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    //몬스터가 끝까지가 가게하고 마지막에 도착했으면 체력을 깍고 없어진다.
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
        // sqrMagnitude는 대략적으로 할때 사용
        if ((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            //Debug.Log("몬스터가 도착해 플레이어 공격");
            OnEndPontArrvied?.Invoke();
            Destroy(gameObject);
        }
    }
}
