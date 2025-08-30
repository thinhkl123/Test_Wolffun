using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    [Header(" Data ")]
    public int ID;
    public ProductionUnit ProductionUnit;
    public bool IsEmpty = true;
    public bool CanHarvest = false;

    [Header(" UI ")]
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI timeText;
    public Button harvestBtn;


    public void AddProductionUnit(ProductionUnit productionUnit)
    {
        ProductionUnit productionUnitGO = Instantiate(productionUnit, this.transform);
        this.ProductionUnit = productionUnitGO;
        IsEmpty = false;
        CanHarvest = false;

        ProductionUnit.StartProduction(this);

        //Debug.Log($"Plot {this.ID} has successfully add {ProductionUnit.ProductName}");
    }

    public void Harvest()
    {
        this.ProductionUnit.Harvest();
        EndProduce();
    }

    public void EndProduce()
    {
        this.ProductionUnit.isProducing = false;
        Destroy(this.ProductionUnit.gameObject);
        IsEmpty = true;
        CanHarvest = false;

        //Update View
        amountText.text = "0/0";
        timeText.text = "00:00";
        harvestBtn.gameObject.SetActive(false);

        //Debug.Log("EndProduce " + ID);
    }

    public void ShowCanHarvest()
    {
        CanHarvest = true;

        //Update View
        harvestBtn.gameObject.SetActive(true);

        //Debug.Log("ShowHarvest " + ID);
    }

    public void UpdateAmountText(int currentAmount, int maxAmount)
    {
        amountText.text = currentAmount.ToString() + "/" + maxAmount.ToString();
    }

    public void UpdateTimeText(double time)
    {
        timeText.text = FormatTime(time);
    }

    private string FormatTime(double seconds)
    {
        if (seconds < 0) seconds = 0;
        int total = (int)System.Math.Floor(seconds);
        int h = total / 3600;
        int m = (total % 3600) / 60;
        int s = total % 60;
        return $"{h:00}:{m:00}:{s:00}";
    }
}
