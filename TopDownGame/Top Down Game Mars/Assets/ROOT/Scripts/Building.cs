using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Building : MonoBehaviour
{

    public string BName;
    int Bvalue;

    [SerializeField]
    private GameObject SelectionCube;
    protected int BuildingLevel = 1;
    [SerializeField]
    protected int ProductionValue;

    public GameObject CurrentModel;

    [SerializeField]
    public List<BuildingUpgrade> EraUpgrades = new List<BuildingUpgrade>();
    


    public void SetSelectionCube (bool isSelected)
    {
        SelectionCube.SetActive(isSelected);
    }

    public int GetGoldUpgradeCost() {
        return EraUpgrades[BuildingLevel - 1].upgradeCost.GoldValue;
    }

    public int GetHydrationUpgradeCost()
    {
        return EraUpgrades[BuildingLevel - 1].upgradeCost.WaterValue;
    }

    public int GetSilverUpgradeCost()
    {
        return EraUpgrades[BuildingLevel - 1].upgradeCost.SilverValue;
    }

    public void UpgradeBuilding() {
        CurrentModel.SetActive(false);
        CurrentModel = EraUpgrades[BuildingLevel - 1].BuildingModel;
        CurrentModel.SetActive(true);

        BuildingLevel++;
    }

    public int GetBValue()
    {
        return Bvalue;
    }

    public virtual void DoProduction(TownManager townManager) { 
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    [Serializable]
    public struct BuildingUpgrade 
    {
        public GameObject BuildingModel;
        public int ValIncrease;
        public CurrencyCost upgradeCost;
    }


}
