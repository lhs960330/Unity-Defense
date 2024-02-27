using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    [SerializeField] CanonBall ballPrefab;
    [SerializeField] Transform canonPoint;
    protected override void OnEnable()
    {
        base.OnEnable();
        attackRoutine = StartCoroutine(AttackRoutine());
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(attackRoutine);
    }

    public void Attack(Vector3 position)
    {
        CanonBall canonBall = Instantiate(ballPrefab, canonPoint.position, canonPoint.rotation);
        canonBall.SetTargetPos(position);
        canonBall.SetDamage(data.towers[level - 1].damage);
    }
    Coroutine attackRoutine;
    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (monsterList.Count > 0)
            {
                int index = 0;
                // monsterList[0] 이 null일때 에러가 떠서 고침
                // index = index + 1 >= monsterList.Count? 0 : index + 1 
                while (monsterList[index] == null)
                {
                    index++;
                    if(index >= monsterList.Count)
                    {
                        index = 0;
                    }
                }

                Attack(monsterList[index].transform.position);
                yield return new WaitForSeconds(data.towers[level - 1].coolTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
