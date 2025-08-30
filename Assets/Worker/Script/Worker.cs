using System;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [Header(" Data ")]
    public bool isFree;
    public DateTime startTime;

    public void Setup()
    {
        isFree = false;
        startTime = DateTime.Now;
    }

    public void Setup(bool isFree, string startTime)
    {
        this.isFree = isFree;
        this.startTime = DateTime.Parse(startTime);
    }

    private void Update()
    {
        if (GameManager.Instance.IsUpdate)
        {
            return;
        }

        if (!isFree)
        {
            double time = (DateTime.Now - startTime).TotalMinutes;
            if (time >= CSVLoader.GetWorkerTimeTaskLevel())
            {
                isFree = true;
                WorkersManager.Instance.UpdateIdleWorker(1);
            }
        }
        if (isFree) 
        {
            Work();
        }
    }

    public void UpdateWork()
    {
        if (!isFree)
        {
            double time = (GameManager.Instance.TimeNow - startTime).TotalMinutes;
            if (time >= CSVLoader.GetWorkerTimeTaskLevel())
            {
                isFree = true;
                WorkersManager.Instance.UpdateIdleWorker(1);
            }
        }
        if (isFree)
        {
            Work();
        }
    }

    private void Work()
    {
        if (!isFree)
        {
            return;
        }

        List<int> random = new List<int>() { 1, 2, 3, 4, 5 };

        while (random.Count > 0)
        {
            int ranIdx = random[UnityEngine.Random.Range(0, random.Count - 1)];
            bool isCompleted = WorkersManager.Instance.Work((WorkType) ranIdx);

            if (isCompleted)
            {
                isFree = false;
                WorkersManager.Instance.UpdateIdleWorker(-1);
                if (GameManager.Instance.IsUpdate)
                {
                    startTime = GameManager.Instance.TimeNow;
                }
                else
                {
                    startTime = DateTime.Now;
                }

                return;
            }

            random.Remove(ranIdx);
        }
    }
}

[Serializable]
public enum WorkType
{
    None = 0,
    FarmTomato = 1,
    FarmBlueberry = 2,
    FarmStrawberry = 3,
    FarmCow = 4,
    Harvest = 5,
}
