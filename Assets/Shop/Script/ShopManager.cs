using UnityEngine;
using CustomUtils;
using TMPro;
using System;

public class ShopManager : SingletonMono<ShopManager>
{
    [Header(" Data ")]
    public ShopModel Data;

    [Header(" View ")]
    public ShopUI shopUI;

    public void Init()
    {
        SetupData();

        SetupUI();
    }

    private void SetupData()
    {
        var row = CSVLoader.GetShopDataByName("Tomato");
        Data.TomatoPrice = float.Parse(row["Price"]);
        Data.TomatoAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Blueberry");
        Data.BlueberryPrice = float.Parse(row["Price"]);
        Data.BlueberryAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Strawberry");
        Data.StrawberryPrice = float.Parse(row["Price"]);
        Data.StrawberryAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Cow");
        Data.CowPrice = float.Parse(row["Price"]);
        Data.CowAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Plot");
        Data.PlotPrice = float.Parse(row["Price"]);
        Data.PlotAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Worker");
        Data.WorkerPrice = float.Parse(row["Price"]);
        Data.WorkerAmount = int.Parse(row["Amount"]);

        row = CSVLoader.GetShopDataByName("Equipment");
        Data.EquipmentPrice = float.Parse(row["Price"]);
        Data.EquipmentAmount = int.Parse(row["Amount"]);
    }

    private void SetupUI()
    {
        shopUI = UIManager.Instance.GetUI<ShopUI>();

        shopUI.UpdateTomatoPrice(Data.TomatoPrice);
        shopUI.UpdateTomatoAmount(Data.TomatoAmount);

        shopUI.UpdateBlueberryPrice(Data.BlueberryPrice);
        shopUI.UpdateBlueberryAmount(Data.BlueberryAmount);

        shopUI.UpdateStrawberryPrice(Data.StrawberryPrice);
        shopUI.UpdateStrawberryAmount(Data.StrawberryAmount);

        shopUI.UpdateCowPrice(Data.CowPrice);
        shopUI.UpdateCowAmount(Data.CowAmount);

        shopUI.UpdatePlotPrice(Data.PlotPrice);
        shopUI.UpdatePlotAmount(Data.PlotAmount);

        shopUI.UpdateWorkerPrice(Data.WorkerPrice);
        shopUI.UpdateWorkerAmount(Data.WorkerAmount);

        shopUI.UpdateEquipmentPrice(Data.EquipmentPrice);
        shopUI.UpdateEquipmentAmount(Data.EquipmentAmount);

        shopUI.OnBuyTomatoClicked += BuyTomato;
        shopUI.OnBuyBlueberryClicked += BuyBlueberry;
        shopUI.OnBuyStrawberryClicked += BuyStrawberry;
        shopUI.OnBuyCowClicked += BuyCow;
        shopUI.OnBuyPlotClicked += BuyPlot;
        shopUI.OnBuyWorkerClicked += BuyWorker;
        shopUI.OnUpgradeEquipmentClicked += UpgradeEquipment;
    }

    public void BuyTomato()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.TomatoPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.TomatoPrice);
            BagManager.Instance.UpdateTomatoAmount(Data.TomatoAmount);
        }
    }

    public void BuyBlueberry()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.BlueberryPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.BlueberryPrice);
            BagManager.Instance.UpdateBlueberryAmount(Data.BlueberryAmount);
        }
    }

    public void BuyStrawberry()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.StrawberryPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.StrawberryPrice);
            BagManager.Instance.UpdateStrawberryAmount(Data.StrawberryAmount);
        }
    }

    public void BuyCow()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.CowPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.CowPrice);
            BagManager.Instance.UpdateCowAmount(Data.CowAmount);
        }
    }

    public void BuyPlot()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.PlotPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.PlotPrice);
            BagManager.Instance.UpdatePlotAmount(Data.PlotAmount);
        }
    }

    public void BuyWorker()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.WorkerPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.WorkerPrice);
            WorkersManager.Instance.AddWorker();
            BagManager.Instance.UpdateWorkerAmount(Data.WorkerAmount);
        }
    }

    public void UpgradeEquipment()
    {
        if (BagManager.Instance.Data.CoinAmount >= Data.EquipmentPrice)
        {
            BagManager.Instance.UpdateCoinAmount(-Data.EquipmentPrice);
            BagManager.Instance.UpdateEquipmentLevel(Data.EquipmentAmount);
        }
    }
}
