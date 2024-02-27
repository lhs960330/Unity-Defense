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
    [SerializeField] int hp;
    // 2. 시간상 이걸로 대체
    [SerializeField] Slider hpBar;
    // 1.체력바 이벤트활용
    public int HP { get { return hp; } private set { hp = value; ; OnChangedHP?.Invoke(value); } }
    public event UnityAction<int> OnChangedHP;

    public UnityAction Ondied;
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
    public void TakeDamage(int damage)
    {
        HP -= damage;
        hpBar.value = HP;
        if (hp <= 0)
        {
            Ondied?.Invoke();
            Destroy(gameObject);
        }
    }
}
