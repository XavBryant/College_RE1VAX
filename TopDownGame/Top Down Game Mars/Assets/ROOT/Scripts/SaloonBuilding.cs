using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaloonBuilding : Building
{
    public override void DoProduction(TownManager townManager)
    {
        townManager.AddWater(ProductionValue);
    }
}
