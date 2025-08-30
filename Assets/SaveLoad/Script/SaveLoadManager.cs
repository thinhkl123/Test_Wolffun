using UnityEngine;
using CustomUtils;
using System;
using System.IO;

public class SaveLoadManager : SingletonMono<SaveLoadManager>
{
    public bool IsLoad;
    [HideInInspector]
    public bool IsExitFile;
    public GameData GameData;

    private string folderPath;
    private string filePath;

    protected override void Awake()
    {
        base.Awake();

        // Set the folder path to the "Data" folder within the project
#if UNITY_EDITOR
        // Editor: lưu thẳng trong Assets/Data/Resources cho dễ debug
        string folderPath = Path.Combine(Application.dataPath, "Data", "Resources");
#else
    // Build: dùng persistentDataPath
    string folderPath = Path.Combine(Application.persistentDataPath, "Data");
#endif
        // Ensure the folder exists
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        // Set the file path to a specific file in the "Data" folder
        filePath = Path.Combine(folderPath, "GameData.json");

        if (IsLoad)
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        GameData gameData = new GameData
        {
            SaveTime = DateTime.Now.ToString("o"),
            BagData = BagManager.Instance.GetBagData(),
            SellData = SellManager.Instance.GetSellData(),
            WorkersData = WorkersManager.Instance.GetWorkersData(),
            PlotsData = PlotsManager.Instance.GetPlotsData(),
        };

        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(filePath, json);

        //Debug.Log("Data Game Save Successfully!");
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData = JsonUtility.FromJson<GameData>(json);
            IsExitFile = true;
        }
        else
        {
            IsExitFile = false;
        }
    }
}
