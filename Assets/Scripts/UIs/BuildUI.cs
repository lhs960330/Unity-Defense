using UnityEngine;

public class BuildUI : InGameUI
{
    private TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();
        // ���ٽ� ǥ��
        buttons["ArchorButton"].onClick.AddListener(() => BuildTower("Archor"));
        buttons["CannonButton"].onClick.AddListener(BuildCannonTower);
        buttons["MageButtont"].onClick.AddListener(BuildMageTower);
        buttons["BarrackButton"].onClick.AddListener(BuildBarrackTower);

    }
    // ���ٽ��� �ƴҶ�
    public void BuildCannonTower()
    {
        towerPlace.BuildTower("Cannon");
        CloseUI();
    }
    public void BuildMageTower()
    {
        towerPlace.BuildTower("Mage");
        CloseUI();

    }
    public void BuildBarrackTower()
    {
        towerPlace.BuildTower("Barrack");
        CloseUI();
    }

    public void BuildTower(string name)
    {
        towerPlace.BuildTower(name);
        CloseUI();
    }
    public void SetTowerPlace(TowerPlace towerPlace)
    {
        this.towerPlace = towerPlace;
    }

}
