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
    [SerializeField] int hp;
    // 2. �ð��� �̰ɷ� ��ü
    [SerializeField] Slider hpBar;
    // 1.ü�¹� �̺�ƮȰ��
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
        // sqrMagnitude�� �뷫������ �Ҷ� ���
        if ((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            //Debug.Log("���Ͱ� ������ �÷��̾� ����");
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
