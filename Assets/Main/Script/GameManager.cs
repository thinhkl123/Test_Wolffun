using UnityEngine;
using CustomUtils;
using System;

public class GameManager : SingletonMono<GameManager>
{
    public Transform Managers;
    public bool IsUpdate;
    public int NumberTime;
    public DateTime TimeNow;

    private void Start()
    {
        CreateObjects();

        if (SaveLoadManager.Instance.IsExitFile)
        {
            UpdateWork();
        }
    }

    private void UpdateWork()
    {
        IsUpdate = true;

        DateTime now = DateTime.Parse(SaveLoadManager.Instance.GameData.SaveTime);
        NumberTime = (int) (DateTime.Now - now).TotalMinutes;

        for (int i = 1; i <= NumberTime; i += 1)
        {
            TimeNow = now.AddMinutes(i);

            WorkersManager.Instance.UpdateWork();
            PlotsManager.Instance.UpdateWork();

            if (BagManager.Instance.IsNoMaterial() && PlotsManager.Instance.IsAllPlotEmpty() 
                && WorkersManager.Instance.IsAllWorkerFree() )
            {
                break;
            }
        }

        IsUpdate = false;
    }

    private void CreateObjects()
    {
        CreateObject("BagManager", "BagManager");
        CreateObject("SellManager", "SellManager");
        CreateObject("ShopManager", "ShopManager");
        CreateObject("WorkersManager", "WorkersManager");
        CreateObject("PlotsManagerCanvas", "PlotsManagerCanvas");

        SellManager.Instance.Init();
        ShopManager.Instance.Init();
        BagManager.Instance.Init();
    }

    private GameObject CreateObject(string module, string nameModule)
    {
        GameObject loginObject = GameObject.Instantiate(Resources.Load<GameObject>(module), Managers);
        loginObject.name = nameModule;

        return loginObject;
    }

    private void OnApplicationQuit()
    {
        SaveLoadManager.Instance.SaveData();
    }
}
