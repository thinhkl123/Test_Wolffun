using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : ProductionUnit
{
    public override void Harvest()
    {
        SellManager.Instance.UpdateTomatoAmount(this.MaxAmount);
    }

    private void Awake()
    {
        LoadData("Tomato");
    }
}
