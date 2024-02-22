using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    //몬스터가 끝까지가 가게하고 마지막에 도착했으면 체력을 깍고 없어진다.
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
        // sqrMagnitude는 대략적으로 할때 사용
        if ((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            //Debug.Log("몬스터가 도착해 플레이어 공격");
            OnEndPontArrvied?.Invoke();
            Destroy(gameObject);
        }
    }
}
