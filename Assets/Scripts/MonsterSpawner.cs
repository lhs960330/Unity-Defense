using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Monster monsterPrefab;
    [SerializeField] float repeatTime;
    [SerializeField] int count;

    private void OnEnable()
    {
        spawnerRoutine = StartCoroutine( SpawnerRoutine());
    }
    private void OnDisable()
    {
        StopCoroutine(spawnerRoutine);
    }

    Coroutine spawnerRoutine;
    IEnumerator SpawnerRoutine()
    {
        while (count > 0)
        {
            count--;
            yield return new WaitForSeconds(repeatTime);
            Monster monster = Instantiate(monsterPrefab, startPoint.position, startPoint.rotation);
            monster.SetDestination(endPoint);
        }
    }
}
