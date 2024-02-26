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
        towerPlace.BuildTower("Barracks");
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
