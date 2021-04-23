using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningBuilding : Building
{
    public override void DoProduction(TownManager townManager) {

        townManager.AddGold(ProductionValue);
        if (BuildingLevel > 2)
        {
            townManager.AddSilver(ProductionValue / 2);
        }

    }
}
