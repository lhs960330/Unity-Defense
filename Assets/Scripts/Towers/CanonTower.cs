using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    [SerializeField] CanonBall ballPrefab;
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
        CanonBall canonBall = Instantiate(ballPrefab, transform.position, transform.rotation);
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
                Attack(monsterList[0].transform.position);
                yield return new WaitForSeconds(data.towers[level - 1].coolTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}
