using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour//, IPointerClickHandler
{
    // 설치할 타워들에게 줄 컴포넌트
    [SerializeField] protected TowerData data;
    [SerializeField] protected int level = 1;

    public List<Monster> monsterList = new List<Monster>();
    public LayerMask monsterMask;

    protected virtual void OnEnable()
    {
        CheckRangeroutine = StartCoroutine(CheckRoutine());
    }
    protected virtual void OnDisable()
    {
        StopCoroutine(CheckRangeroutine);
    }
    // OnDrawGizmos 항상 보여주는 친구, OnDrawGizmosSelected 선택했을 때 보여주는 친구 (게임 씬에서만)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, data.towers[level - 1].range);
    }


    Coroutine CheckRangeroutine;
    IEnumerator CheckRoutine()
    {
        Collider[] colliders = new Collider[30];
        while (true)
        {
            monsterList.Clear();

            // 오버랩은 프레임단위당 해주는게 아니라 딱 한번 해주는 메서드이다.(단발성)
            // 즉 Update에 넣는건 별로 안좋은 선택
            // 얘 사용하면 가비지 계속 발생 줄이고싶으면 OverlapSphereNonAlloc이거 사용하셈
            // Collider[] colliders = Physics.OverlapSphere(transform.position, data.towers[level - 1].range, monsterMask);
            int size = Physics.OverlapSphereNonAlloc(transform.position, data.towers[level - 1].range, colliders, monsterMask);
            for (int i = 0; i < size; i++)
            {
                Monster monster = colliders[i].GetComponent<Monster>();
                monsterList.Add(monster);
            }
            yield return new WaitForSeconds(data.towers[level - 1].coolTime);
          
        }
    }




















    /*[SerializeField] MeshFilter meshFilter;

    private TowerPlace towerPlace;
    private int level = 1;
    private bool isUpgrading;

    private void Start()
    {
        Upgrade();
    }
    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }
    public void Upgrade()
    {
        if (level == data.towers.Length)
            return;

        if (isUpgrading)
            return;
        StartCoroutine(UpgradeRutine(level));
    }
    public void Sell()
    {
        Destroy(gameObject);
        towerPlace.gameObject.SetActive(true);
    }

    Coroutine UpgradRoutine;
    IEnumerator UpgradeRutine(int level)
    {
        meshFilter.mesh = data.towers[level].cons;
        isUpgrading = true;
        yield return new WaitForSeconds(data.towers[level].buildTime);
        meshFilter.mesh = data.towers[level].build;
        isUpgrading = false;
        this.level++;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Upgrade();
        }
        else
        {
            Sell();
        }
    }

    // 기지모가 그려질때 보여주는 함수
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (level > 0)
        {
            Gizmos.DrawWireSphere(transform.position, data.towers[level - 1].range);
        }
    }
*/
}
