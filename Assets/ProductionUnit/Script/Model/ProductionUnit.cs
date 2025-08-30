using System;
using UnityEngine;

public abstract class ProductionUnit : MonoBehaviour
{
    [Header(" Data ")]
    public int ID;
    public string ProductName;
    public ProductType ProductType;
    public float ProductionTime;
    public int OutputAmount;
    public int MaxAmount;
    public float TimeDestroy;

    public bool isProducing = false;
    public DateTime startProduceTime;

    [Header(" Reference ")]
    public Plot plot;


    protected virtual void LoadData(string unitName)
    {
        var row = CSVLoader.GetProductionUnitDataByName(unitName);
        if (row == null) return;

        ID = int.Parse(row["ID"]);
        ProductName = row["Name"];
        ProductionTime = float.Parse(row["ProductionTime"]);
        OutputAmount = int.Parse(row["OutputAmount"]);
        MaxAmount = int.Parse(row["MaxAmount"]);
        TimeDestroy = float.Parse(row["TimeDestroy"]);
    }

    public void StartProduction(Plot plot)
    {
        this.plot = plot;

        isProducing = true;
        if (GameManager.Instance.IsUpdate)
        {
            startProduceTime = GameManager.Instance.TimeNow;
        }
        else
        {
            startProduceTime = DateTime.Now;
        }

        //Update View
        plot.UpdateAmountText(0, MaxAmount);
    }

    private void Update()
    {
        if (GameManager.Instance.IsUpdate)
        {
            return;
        }

        if (isProducing)
        {
            float productionTime = this.ProductionTime / 
                (CSVLoader.GetUpgradeIndexEquipmentLevel() * (BagManager.Instance.Data.EquipmentLevel - 1) + 1);
            double time = (DateTime.Now - startProduceTime).TotalMinutes;
            if (time >= productionTime * this.MaxAmount + this.TimeDestroy)
            {
                plot.EndProduce();

                return;
            }
            else if (time >= productionTime * this.MaxAmount)
            {
                plot.ShowCanHarvest();
            }

            //Update View
            UpdateView(DateTime.Now);
        }
    }

    public void UpdateWork()
    {
        if (isProducing)
        {
            float productionTime = this.ProductionTime /
                (CSVLoader.GetUpgradeIndexEquipmentLevel() * (BagManager.Instance.Data.EquipmentLevel - 1) + 1);
            double time = (GameManager.Instance.TimeNow - startProduceTime).TotalMinutes;
            if (time >= productionTime * this.MaxAmount + this.TimeDestroy)
            {
                plot.EndProduce();

                return;
            }
            else if (time >= productionTime * this.MaxAmount)
            {
                plot.ShowCanHarvest();
            }

            //Update View
            UpdateView(GameManager.Instance.TimeNow);
        }
    }

    public abstract void Harvest();

    public void UpdateView(DateTime dateTime)
    {
        if (isProducing)
        {
            float productionTime = this.ProductionTime /
                    (CSVLoader.GetUpgradeIndexEquipmentLevel() * (BagManager.Instance.Data.EquipmentLevel - 1) + 1);
            double time = (dateTime - startProduceTime).TotalSeconds;
            int productAmount = (int)(time / productionTime / 60);

            if (productAmount > this.MaxAmount)
            {
                productAmount = this.MaxAmount;
            }

            plot.UpdateAmountText(productAmount, this.MaxAmount);
            if (time >= productionTime * this.MaxAmount * 60)
            {
                double timeUI = this.TimeDestroy * 60 - (time - productionTime * 60 * this.MaxAmount);
                plot.UpdateTimeText(timeUI);
            }
            else
            {
                double timeUI = productionTime * 60 * this.MaxAmount - time;
                plot.UpdateTimeText(timeUI);
            }
        }
    }
}

[Serializable]
public enum ProductType
{
    None = 0,
    Tomato = 1,
    Blueberry = 2,
    Strawberry = 3,
    Cow = 4,
}
