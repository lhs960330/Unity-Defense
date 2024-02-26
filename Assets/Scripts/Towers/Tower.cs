using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    // 설치할 타워들에게 줄 컴포넌트
    [SerializeField] TowerData data;
    [SerializeField] MeshFilter meshFilter;

    private TowerPlace towerPlace;
    private int level;
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

}
