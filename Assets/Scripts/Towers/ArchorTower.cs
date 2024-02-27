using System.Collections;
using UnityEngine;

public class ArchorTower : Tower
{
    [SerializeField] Arrow arrowPrefab;
    [SerializeField] Transform archor;
    [SerializeField] Transform arrowPoint;

    private void Update()
    {
        Look();
    }
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
    private void Attack(Monster monster)
    {
        Arrow arrow = Instantiate(arrowPrefab, arrowPoint.position, arrowPoint.rotation);
        arrow.SetTarget(monster);
        arrow.SetDamage(data.towers[level - 1].damage);
    }

    private void Look()
    {
        if (monsterList.Count == 0)
            return;

        if (monsterList[0] != null)
        {
            Vector3 dir = (monsterList[0].transform.position - transform.position).normalized;
            archor.transform.rotation = Quaternion.LookRotation(dir);
        }
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
                    if (index >= monsterList.Count)
                    {
                        index = monsterList.Count - 1;
                        break;
                    }
                }
                Attack(monsterList[index]);
                yield return new WaitForSeconds(data.towers[level - 1].coolTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
