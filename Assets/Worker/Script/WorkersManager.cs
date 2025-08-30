using UnityEngine;
using CustomUtils;
using System.Collections.Generic;
using System;

public class WorkersManager : SingletonMono<WorkersManager>
{
    public int IdleWorker;

    [Header(" Prefab ")]
    [SerializeField] private Worker WorkerPrefab;

    private List<Worker> workers = new List<Worker>();

    public void Init(int count)
    {
        if (!SaveLoadManager.Instance.IsExitFile)
        {
            IdleWorker = 0;
            for (int i = 0; i < count; i++)
            {
                Worker w = Instantiate(WorkerPrefab, this.transform);
                w.Setup();
                workers.Add(w);
            }
        }
        else
        {
            IdleWorker = SaveLoadManager.Instance.GameData.WorkersData.IdleWorker;
            for (int i = 0; i < count; i++)
            {
                Worker w = Instantiate(WorkerPrefab, this.transform);
                WorkerData workerData = SaveLoadManager.Instance.GameData.WorkersData.Workers[i];
                w.Setup(workerData.IsFree, workerData.StartTime);
                workers.Add(w);
            }
        }    
    }

    public void AddWorker()
    {
        Worker w = Instantiate(WorkerPrefab, this.transform);
        w.Setup();
        workers.Add(w);
    }

    public void UpdateIdleWorker(int amount)
    {
        IdleWorker += amount;
        BagManager.Instance.UpdateWorkerAmount(0);
    }

    public void UpdateWork()
    {
        foreach (Worker w in workers) 
        {
            w.UpdateWork();
        }
    }

    public bool Work(WorkType type)
    {
        switch (type)
        {
            case WorkType.FarmTomato: 
                return BagManager.Instance.FarmTomato();
            case WorkType.FarmBlueberry: 
                return BagManager.Instance.FarmBlueberry();
            case WorkType.FarmStrawberry: 
                return BagManager.Instance.FarmStrawberry();
            case WorkType.FarmCow: 
                return BagManager.Instance.FarmCow();
            case WorkType.Harvest: 
                return PlotsManager.Instance.HarvestRandom();
        }
        return false;
    }

    public bool IsAllWorkerFree()
    {
        foreach (Worker w in workers)
        {
            if (!w.isFree)
            {
                return false;
            }
        }

        return true;
    }

    public WorkersData GetWorkersData()
    {
        List<WorkerData> workerDatas = new List<WorkerData>();

        foreach (Worker w in workers)
        {
            WorkerData workerData = new WorkerData
            {
                IsFree = w.isFree,
                StartTime = w.startTime.ToString("o"),
            };
            
            workerDatas.Add(workerData);
        }

        WorkersData data = new WorkersData
        {
            IdleWorker = this.IdleWorker,
            Workers = workerDatas,
        };

        return data;
    }
}
