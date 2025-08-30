using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : UICanvas
{
    [Header("Amount Text")]
    public TextMeshProUGUI TomatoAmountText;
    public TextMeshProUGUI BlueberryAmountText;
    public TextMeshProUGUI StrawberryAmountText;
    public TextMeshProUGUI CowAmountText;
    public TextMeshProUGUI WorkerAmountText;
    public TextMeshProUGUI EquipmentLevelText;
    public TextMeshProUGUI CoinAmountText;

    [Header("Button")]
    public Button FarmTomatoButton;
    public Button FarmBlueberryButton;
    public Button FarmStrawberryButton;
    public Button FarmCowButton;

    //Event
    public event Action OnFarmTomatoClicked;
    public event Action OnFarmBlueberryClicked;
    public event Action OnFarmStrawberryClicked;
    public event Action OnFarmCowClicked;

    private void Awake()
    {
        FarmTomatoButton.onClick.AddListener(() => OnFarmTomatoClicked?.Invoke());
        FarmBlueberryButton.onClick.AddListener(() => OnFarmBlueberryClicked?.Invoke());
        FarmStrawberryButton.onClick.AddListener(() => OnFarmStrawberryClicked?.Invoke());
        FarmCowButton.onClick.AddListener(() => OnFarmCowClicked?.Invoke());
    }

    public virtual void UpdateTomatoAmount(int value) => TomatoAmountText.text = value.ToString();
    public virtual void UpdateBlueberryAmount(int value) => BlueberryAmountText.text = value.ToString();
    public virtual void UpdateStrawberryAmount(int value) => StrawberryAmountText.text = value.ToString();
    public virtual void UpdateCowAmount(int value) => CowAmountText.text = value.ToString();
    public virtual void UpdateWorkerAmount(int idleWorker, int sum) 
        => WorkerAmountText.text = idleWorker.ToString() + "/" + sum.ToString();
    public virtual void UpdateEquipmentLevel(int level) => EquipmentLevelText.text = level.ToString();
    public virtual void UpdateCoinAmount(float value) => CoinAmountText.text = value.ToString();
}
