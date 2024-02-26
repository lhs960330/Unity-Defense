using UnityEngine;

public class BuildUI : InGameUI
{
    private TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();
        // 람다식 표현
        buttons["ArchorButton"].onClick.AddListener(() => BuildTower("Archor"));
        buttons["CannonButton"].onClick.AddListener(BuildCannonTower);
        buttons["MageButtont"].onClick.AddListener(BuildMageTower);
        buttons["BarrackButton"].onClick.AddListener(BuildBarrackTower);

    }
    // 람다식이 아닐때
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
