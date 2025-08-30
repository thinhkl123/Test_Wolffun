using UnityEngine;
using CustomUtils;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class BagManager : SingletonMono<BagManager>
{
    [Header(" Data ")]
    public BagModel Data = new BagModel();

    [Header(" Prefab ")]
    public Tomato Tomato;
    public Blueberry Blueberry;
    public Strawberry Strawberry;
    public Cow Cow;

    [Header(" View ")]
    public BagUI BagUI;

    public void Init()
    {
        SetupData();

        PlotsManager.Instance.SpawnPlot(Data.PlotAmount);
        WorkersManager.Instance.Init(Data.WorkerAmount);

        SetupUI();
    }

    private void SetupData()
    {
        if (!SaveLoadManager.Instance.IsExitFile)
        {
            var row = CSVLoader.GetInitDataByName("Plot");
            Data.PlotAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Tomato");
            Data.TomatoAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Blueberry");
            Data.BlueberryAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Strawberry");
            Data.StrawberryAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Cow");
            Data.CowAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Worker");
            Data.WorkerAmount = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Equipment");
            Data.EquipmentLevel = int.Parse(row["Amount"]);
            row = CSVLoader.GetInitDataByName("Coin");
            Data.CoinAmount = float.Parse(row["Amount"]);
        }
        else
        {
            Data.PlotAmount = SaveLoadManager.Instance.GameData.BagData.PlotAmount;
            Data.TomatoAmount = SaveLoadManager.Instance.GameData.BagData.TomatoSeed;
            Data.BlueberryAmount = SaveLoadManager.Instance.GameData.BagData.BlueberrySeed;
            Data.StrawberryAmount = SaveLoadManager.Instance.GameData.BagData.StrawberrySeed;
            Data.CowAmount = SaveLoadManager.Instance.GameData.BagData.CowAmount;
            Data.WorkerAmount = SaveLoadManager.Instance.GameData.BagData.WorkerAmount;
            Data.EquipmentLevel = SaveLoadManager.Instance.GameData.BagData.EquipmentLevel;
            Data.CoinAmount = SaveLoadManager.Instance.GameData.BagData.CoinAmount;
        }
    }

    private void SetupUI()
    {
        BagUI = UIManager.Instance.GetUI<BagUI>();

        BagUI.UpdateTomatoAmount(Data.TomatoAmount);
        BagUI.UpdateBlueberryAmount(Data.BlueberryAmount);
        BagUI.UpdateStrawberryAmount(Data.StrawberryAmount);
        BagUI.UpdateCowAmount(Data.CowAmount);
        BagUI.UpdateWorkerAmount(WorkersManager.Instance.IdleWorker, Data.WorkerAmount);
        BagUI.UpdateEquipmentLevel(Data.EquipmentLevel);
        BagUI.UpdateCoinAmount(Data.CoinAmount);

        BagUI.OnFarmTomatoClicked += () => Farm("Tomato");
        BagUI.OnFarmBlueberryClicked += () => Farm("Blueberry");
        BagUI.OnFarmStrawberryClicked += () => Farm("Strawberry");
        BagUI.OnFarmCowClicked += () => Farm("Cow");
    }

    public void Farm(string productName)
    {
        switch (productName)
        {
            case "Tomato":
                FarmTomato();

                break;

            case "Blueberry":
                FarmBlueberry();

                break;

            case "Strawberry":
                FarmStrawberry();

                break;

            case "Cow":
                FarmCow();

                break;
        }
    }

    public bool FarmTomato()
    {
        if (Data.TomatoAmount > 0)
        {
            if (PlotsManager.Instance.AddProductionUnit(Tomato))
            {
                this.UpdateTomatoAmount(-1);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool FarmBlueberry()
    {
        if (Data.BlueberryAmount > 0)
        {
            if (PlotsManager.Instance.AddProductionUnit(Blueberry))
            {
                this.UpdateBlueberryAmount(-1);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool FarmStrawberry()
    {
        if (Data.StrawberryAmount > 0)
        {
            if (PlotsManager.Instance.AddProductionUnit(Strawberry))
            {
                this.UpdateStrawberryAmount(-1);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool FarmCow()
    {
        if (Data.CowAmount > 0)
        {
            if (PlotsManager.Instance.AddProductionUnit(Cow))
            {
                this.UpdateCowAmount(-1);

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void UpdatePlotAmount(int amount)
    {
        Data.PlotAmount += amount;

        PlotsManager.Instance.AddPlot(amount);
    }

    public void UpdateTomatoAmount(int amount)
    {
        Data.TomatoAmount += amount;

        BagUI.UpdateTomatoAmount(Data.TomatoAmount);
    }

    public void UpdateBlueberryAmount(int amount)
    {
        Data.BlueberryAmount += amount;

        BagUI.UpdateBlueberryAmount(Data.BlueberryAmount);
    }

    public void UpdateStrawberryAmount(int amount)
    {
        Data.StrawberryAmount += amount;

        BagUI.UpdateStrawberryAmount(Data.StrawberryAmount);
    }

    public void UpdateCowAmount(int amount)
    {
        Data.CowAmount += amount;

        BagUI.UpdateCowAmount(Data.CowAmount);
    }

    public void UpdateWorkerAmount(int amount)
    {
        Data.WorkerAmount += amount;

        BagUI.UpdateWorkerAmount(WorkersManager.Instance.IdleWorker, Data.WorkerAmount);
    }

    public void UpdateEquipmentLevel(int amount)
    {
        Data.EquipmentLevel += amount;

        BagUI.UpdateEquipmentLevel(Data.EquipmentLevel);
    }

    public void UpdateCoinAmount(float amount)
    {
        Data.CoinAmount += amount;

        BagUI.UpdateCoinAmount(Data.CoinAmount);
    }

    public bool IsNoMaterial()
    {
        return Data.TomatoAmount == 0 && Data.BlueberryAmount == 0 && Data.StrawberryAmount == 0 && Data.CowAmount == 0;
    }

    public BagData GetBagData()
    {
        BagData bagData = new BagData
        {
            PlotAmount = Data.PlotAmount,
            TomatoSeed = Data.TomatoAmount,
            BlueberrySeed = Data.BlueberryAmount,
            StrawberrySeed = Data.StrawberryAmount,
            CowAmount = Data.CowAmount,
            WorkerAmount = Data.WorkerAmount,
            EquipmentLevel = Data.EquipmentLevel,
            CoinAmount = Data.CoinAmount,
        };

        return bagData;
    }
}
