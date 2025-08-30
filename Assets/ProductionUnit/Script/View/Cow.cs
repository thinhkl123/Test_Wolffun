using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : ProductionUnit
{
    public override void Harvest()
    {
        SellManager.Instance.UpdateMilkAmount(this.MaxAmount);
    }

    private void Awake()
    {
        LoadData("Cow");
    }
}
