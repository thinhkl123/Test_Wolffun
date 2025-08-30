using UnityEngine;
using CustomUtils;
using TMPro;
using System;

public class SellManager : SingletonMono<SellManager>
{
    [Header(" Data ")]
    public SellModel Data = new SellModel();

    [Header(" View ")]
    public SellUI SellUI;

    public void Init()
    {
        SetupData();

        SetupUI();
    }

    private void SetupData()
    {
        //Load Amount
        if (SaveLoadManager.Instance.IsExitFile)
        {
            Data.TomatoAmount = SaveLoadManager.Instance.GameData.SellData.TomatoAmount;
            Data.BlueberryAmount = SaveLoadManager.Instance.GameData.SellData.BlueberryAmount;
            Data.StrawberryAmount = SaveLoadManager.Instance.GameData.SellData.StrawberryAmount;
            Data.MilkAmount = SaveLoadManager.Instance.GameData.SellData.MilkAmount;
        }
        else
        {
            Data.TomatoAmount = 0;
            Data.BlueberryAmount = 0;
            Data.StrawberryAmount = 0;
            Data.MilkAmount = 0;
        }

        //Load Price
        var row = CSVLoader.GetSellDataByName("Tomato");
        Data.TomatoPrice = float.Parse(row["Price"]);
        row = CSVLoader.GetSellDataByName("Blueberry");
        Data.BlueberryPrice = float.Parse(row["Price"]);
        row = CSVLoader.GetSellDataByName("Strawberry");
        Data.StrawberryPrice = float.Parse(row["Price"]);
        row = CSVLoader.GetSellDataByName("Milk");
        Data.MilkPrice = float.Parse(row["Price"]);
    }

    private void SetupUI()
    {
        this.SellUI = UIManager.Instance.GetUI<SellUI>();

        SellUI.UpdateTomatoPrice(Data.TomatoPrice);
        SellUI.UpdateBlueberryPrice(Data.BlueberryPrice);
        SellUI.UpdateStrawberryPrice(Data.StrawberryPrice);
        SellUI.UpdateMilkPrice(Data.MilkPrice);

        SellUI.UpdateTomatoAmount(Data.TomatoAmount);
        SellUI.UpdateBlueberryAmount(Data.BlueberryAmount);
        SellUI.UpdateStrawberryAmount(Data.StrawberryAmount);
        SellUI.UpdateMilkAmount(Data.MilkAmount);

        SellUI.OnSellTomatoClicked += SellTomato;
        SellUI.OnSellBlueberryClicked += SellBlueberry;
        SellUI.OnSellStrawberryClicked += SellStrawberry;
        SellUI.OnSellMilkClicked += SellMilk;
    }

    public void SellTomato()
    {
        BagManager.Instance.UpdateCoinAmount(Data.TomatoAmount * Data.TomatoPrice);

        //Update View
        UpdateTomatoAmount(-Data.TomatoAmount);
    }

    public void SellBlueberry()
    {
        BagManager.Instance.UpdateCoinAmount(Data.BlueberryAmount * Data.BlueberryPrice);

        //Update View
        UpdateBlueberryAmount(-Data.BlueberryAmount);
    }

    public void SellStrawberry()
    {
        BagManager.Instance.UpdateCoinAmount(Data.StrawberryAmount * Data.StrawberryPrice);

        //Update View
        UpdateStrawberryAmount(-Data.StrawberryAmount);
    }

    public void SellMilk()
    {
        BagManager.Instance.UpdateCoinAmount(Data.MilkAmount * Data.MilkPrice);

        //Update View
        UpdateMilkAmount(-Data.MilkAmount);
    }

    public void UpdateTomatoAmount(int amount)
    {
        Data.TomatoAmount += amount;
        SellUI.UpdateTomatoAmount(Data.TomatoAmount);
    }

    public void UpdateBlueberryAmount(int amount)
    {
        Data.BlueberryAmount += amount;
        SellUI.UpdateBlueberryAmount(Data.BlueberryAmount);
    }

    public void UpdateStrawberryAmount(int amount)
    {
        Data.StrawberryAmount += amount;
        SellUI.UpdateStrawberryAmount(Data.StrawberryAmount);
    }

    public void UpdateMilkAmount(int amount)
    {
        Data.MilkAmount += amount;
        SellUI.UpdateMilkAmount(Data.MilkAmount);
    }

    public SellData GetSellData()
    {
        SellData sellData = new SellData
        {
            TomatoAmount = Data.TomatoAmount,
            BlueberryAmount = Data.BlueberryAmount,
            StrawberryAmount = Data.StrawberryAmount,
            MilkAmount = Data.MilkAmount,
        };

        return sellData;
    }
}
