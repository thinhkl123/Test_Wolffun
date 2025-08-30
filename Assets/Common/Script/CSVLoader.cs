using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    private static Dictionary<string, Dictionary<string, string>> productionUnitData;
    private static Dictionary<string, Dictionary<string, string>> shopData;
    private static Dictionary<string, Dictionary<string, string>> sellData;
    private static Dictionary<string, Dictionary<string, string>> initData;

    private static float equipmentUpgrade;
    private static float workerTimeTask;

    void Awake()
    {
        LoadProductionUnitData();
        LoadShopData();
        LoadSellData();
        LoadInitData();
        LoadUpgradeIndexEquipmentLevel();
        LoadWorkerTimeTaskLevel();
    }

    private void LoadProductionUnitData()
    {
        productionUnitData = new Dictionary<string, Dictionary<string, string>>();

        TextAsset csvData = Resources.Load<TextAsset>("ProductionUnit");
        if (csvData == null)
        {
            Debug.LogError("No Found ProductionUnit.csv!");
            return;
        }

        StringReader reader = new StringReader(csvData.text);

        string headerLine = reader.ReadLine();
        string[] headers = headerLine.Split(',');

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            if (values.Length != headers.Length) continue;

            Dictionary<string, string> entry = new Dictionary<string, string>();
            for (int i = 0; i < headers.Length; i++)
            {
                entry[headers[i]] = values[i];
            }

            string nameKey = entry["Name"];
            productionUnitData[nameKey] = entry;
        }
    }

    public static Dictionary<string, string> GetProductionUnitDataByName(string name)
    {
        if (productionUnitData != null && productionUnitData.ContainsKey(name))
            return productionUnitData[name];

        Debug.LogError("No found Production Unit Data for: " + name);
        return null;
    }

    private void LoadShopData()
    {
        shopData = new Dictionary<string, Dictionary<string, string>>();

        TextAsset csvData = Resources.Load<TextAsset>("ShopData");
        if (csvData == null)
        {
            Debug.LogError("No Found ShopData.csv!");
            return;
        }

        StringReader reader = new StringReader(csvData.text);

        string headerLine = reader.ReadLine();
        string[] headers = headerLine.Split(',');

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            if (values.Length != headers.Length) continue;

            Dictionary<string, string> entry = new Dictionary<string, string>();
            for (int i = 0; i < headers.Length; i++)
            {
                entry[headers[i]] = values[i];
            }

            string nameKey = entry["Name"];
            shopData[nameKey] = entry;
        }
    }

    public static Dictionary<string, string> GetShopDataByName(string name)
    {
        if (shopData != null && shopData.ContainsKey(name))
            return shopData[name];

        Debug.LogError("No found Shop Data for: " + name);
        return null;
    }

    private void LoadInitData()
    {
        initData = new Dictionary<string, Dictionary<string, string>>();

        TextAsset csvData = Resources.Load<TextAsset>("InitData");
        if (csvData == null)
        {
            Debug.LogError("No Found InitData.csv!");
            return;
        }

        StringReader reader = new StringReader(csvData.text);

        string headerLine = reader.ReadLine();
        string[] headers = headerLine.Split(',');

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            if (values.Length != headers.Length) continue;

            Dictionary<string, string> entry = new Dictionary<string, string>();
            for (int i = 0; i < headers.Length; i++)
            {
                entry[headers[i]] = values[i];
            }

            string nameKey = entry["Name"];
            initData[nameKey] = entry;
        }
    }

    public static Dictionary<string, string> GetInitDataByName(string name)
    {
        if (initData != null && initData.ContainsKey(name))
            return initData[name];

        Debug.LogError("No found Init Data for: " + name);
        return null;
    }

    private void LoadUpgradeIndexEquipmentLevel()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("EquipmentData");
        if (textAsset == null)
        {
            Debug.LogError("No Found EquipmentData.csv!");
            return;
        }

        string[] lines = textAsset.text.Split('\n');
        if (lines.Length > 1 && float.TryParse(lines[1], out float value))
        {
            equipmentUpgrade = value;
        }
    }

    public static float GetUpgradeIndexEquipmentLevel()
    {
        return equipmentUpgrade;
    }

    private void LoadWorkerTimeTaskLevel()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("WorkerData");
        if (textAsset == null)
        {
            Debug.LogError("No Found WorkerData.csv!");
            return;
        }

        string[] lines = textAsset.text.Split('\n');
        if (lines.Length > 1 && float.TryParse(lines[1], out float value))
        {
            workerTimeTask = value;
        }
    }

    public static float GetWorkerTimeTaskLevel()
    {
        return workerTimeTask;
    }

    public static Dictionary<string, string> GetSellDataByName(string name)
    {
        if (sellData != null && sellData.ContainsKey(name))
            return sellData[name];

        Debug.LogError("No found Sell Data for: " + name);
        return null;
    }

    private void LoadSellData()
    {
        sellData = new Dictionary<string, Dictionary<string, string>>();

        TextAsset csvData = Resources.Load<TextAsset>("SellData");
        if (csvData == null)
        {
            Debug.LogError("No Found SellData.csv!");
            return;
        }

        StringReader reader = new StringReader(csvData.text);

        string headerLine = reader.ReadLine();
        string[] headers = headerLine.Split(',');

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            if (values.Length != headers.Length) continue;

            Dictionary<string, string> entry = new Dictionary<string, string>();
            for (int i = 0; i < headers.Length; i++)
            {
                entry[headers[i]] = values[i];
            }

            string nameKey = entry["Name"];
            sellData[nameKey] = entry;
        }
    }
}
