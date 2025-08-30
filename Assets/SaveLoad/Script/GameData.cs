using System;
using System.Collections.Generic;

[Serializable]
public class GameData 
{
    public string SaveTime;
    public BagData BagData;
    public SellData SellData;
    public WorkersData WorkersData;
    public PlotsData PlotsData;
}

[Serializable]
public class BagData
{
    public int PlotAmount;
    public int TomatoSeed;
    public int BlueberrySeed;
    public int StrawberrySeed;
    public int CowAmount;
    public int WorkerAmount;
    public int EquipmentLevel;
    public float CoinAmount;
}

[Serializable]
public class SellData
{
    public int TomatoAmount;
    public int BlueberryAmount;
    public int StrawberryAmount;
    public int MilkAmount;
}

[Serializable]
public class WorkersData
{
    public int IdleWorker;
    public List<WorkerData> Workers;
}

[Serializable]
public class WorkerData
{
    public bool IsFree;
    public string StartTime;
}

[Serializable]
public class PlotsData
{
    public List<PlotData> Plots;
}

[Serializable]
public class PlotData
{
    public ProductionUnitData ProductionUnit;
    public bool IsEmpty;
    public bool CanHarvest;
}

[Serializable]
public class ProductionUnitData
{
    public int ProductType;
    public bool IsProducing;
    public string StartProduceTime;
}