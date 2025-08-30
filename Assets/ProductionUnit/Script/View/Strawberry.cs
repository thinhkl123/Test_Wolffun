using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : ProductionUnit
{
    public override void Harvest()
    {
        SellManager.Instance.UpdateStrawberryAmount(this.MaxAmount);
    }

    private void Awake()
    {
        LoadData("Strawberry");
    }
}
