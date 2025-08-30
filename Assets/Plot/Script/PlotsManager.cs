using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtils;
using System;

public class PlotsManager : SingletonMono<PlotsManager>
{
    [Header(" Data ")]
    public List<Plot> Plots;

    [Header(" Prefab ")]
    public Plot PlotPrefab;

    public void SpawnPlot(int count)
    {
        if (!SaveLoadManager.Instance.IsExitFile)
        {
            for (int i = 0; i < count; i++)
            {
                Plot plotGO = Instantiate(PlotPrefab, this.transform);
                plotGO.ID = i + 1;
                this.Plots.Add(plotGO);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                PlotData plotData = SaveLoadManager.Instance.GameData.PlotsData.Plots[i];

                Plot plotGO = Instantiate(PlotPrefab, this.transform);
                plotGO.ID = i + 1;
                plotGO.IsEmpty = plotData.IsEmpty;
                plotGO.CanHarvest = plotData.CanHarvest;

                ProductionUnit productionUnitGO = null;

                switch (plotData.ProductionUnit.ProductType)
                {
                    case 1:
                        productionUnitGO = Instantiate(BagManager.Instance.Tomato, plotGO.transform);
                        productionUnitGO.isProducing = plotData.ProductionUnit.IsProducing;
                        productionUnitGO.startProduceTime = DateTime.Parse(plotData.ProductionUnit.StartProduceTime);

                        productionUnitGO.plot = plotGO;
                        productionUnitGO.UpdateView(DateTime.Parse(SaveLoadManager.Instance.GameData.SaveTime));

                        break;
                    case 2:
                        productionUnitGO = Instantiate(BagManager.Instance.Blueberry, plotGO.transform);
                        productionUnitGO.isProducing = plotData.ProductionUnit.IsProducing;
                        productionUnitGO.startProduceTime = DateTime.Parse(plotData.ProductionUnit.StartProduceTime);

                        productionUnitGO.plot = plotGO;
                        productionUnitGO.UpdateView(DateTime.Parse(SaveLoadManager.Instance.GameData.SaveTime));

                        break;
                    case 3:
                        productionUnitGO = Instantiate(BagManager.Instance.Strawberry, plotGO.transform);
                        productionUnitGO.isProducing = plotData.ProductionUnit.IsProducing;
                        productionUnitGO.startProduceTime = DateTime.Parse(plotData.ProductionUnit.StartProduceTime);

                        productionUnitGO.plot = plotGO;
                        productionUnitGO.UpdateView(DateTime.Parse(SaveLoadManager.Instance.GameData.SaveTime));

                        break;
                    case 4:
                        productionUnitGO = Instantiate(BagManager.Instance.Cow, plotGO.transform);
                        productionUnitGO.isProducing = plotData.ProductionUnit.IsProducing;
                        productionUnitGO.startProduceTime = DateTime.Parse(plotData.ProductionUnit.StartProduceTime);

                        productionUnitGO.plot = plotGO;
                        productionUnitGO.UpdateView(DateTime.Parse(SaveLoadManager.Instance.GameData.SaveTime));

                        break;
                }

                plotGO.ProductionUnit = productionUnitGO;

                this.Plots.Add(plotGO);
            }
        }
    }

    public void AddPlot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Plot plotGO = Instantiate(PlotPrefab, this.transform);
            plotGO.ID = Plots.Count + 1;
            this.Plots.Add(plotGO);
        }
    }

    public bool AddProductionUnit(ProductionUnit productionUnit)
    {
        foreach (Plot plot in Plots)
        {
            if (plot.IsEmpty)
            {
                plot.AddProductionUnit(productionUnit);

                return true;
            }
        }

        //Debug.LogWarning("No available plot!!!!");
        return false;
    }

    public bool HarvestRandom()
    {
        foreach (Plot plot in Plots)
        {
            if (plot.CanHarvest)
            {
                plot.Harvest();

                return true;
            }
        }

        return false;
    }

    public void UpdateWork()
    {
        foreach (Plot plot in Plots)
        {
            if (plot.ProductionUnit != null)
            {
                plot.ProductionUnit.UpdateWork();
            }
        }
    }

    public bool IsAllPlotEmpty()
    {
        foreach (Plot plot in Plots)
        {
            if (!plot.IsEmpty)
            {
                return false;
            }
        }

        return true;
    }

    public PlotsData GetPlotsData()
    {
        List<PlotData> plotDatas = new List<PlotData>();

        foreach (Plot plot in Plots)
        {
            ProductionUnitData productionUnitData = null;
            if (plot.ProductionUnit != null)
            {
                productionUnitData = new ProductionUnitData
                {
                    ProductType = (int)plot.ProductionUnit.ProductType,
                    IsProducing = plot.ProductionUnit.isProducing,
                    StartProduceTime = plot.ProductionUnit.startProduceTime.ToString("o"),
                };
            }

            PlotData plotData = new PlotData
            {
                ProductionUnit = productionUnitData,
                IsEmpty = plot.IsEmpty,
                CanHarvest = plot.CanHarvest,
            };

            plotDatas.Add(plotData);
        }

        PlotsData data = new PlotsData
        {
            Plots = plotDatas,
        };

        return data;
    }
}
