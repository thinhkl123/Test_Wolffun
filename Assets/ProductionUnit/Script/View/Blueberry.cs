using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueberry : ProductionUnit
{
    public override void Harvest()
    {
        SellManager.Instance.UpdateBlueberryAmount(this.MaxAmount);
    }

    private void Awake()
    {
        LoadData("Blueberry");
    }
}
