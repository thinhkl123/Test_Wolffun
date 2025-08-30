using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : UICanvas
{
    [Header("Text")]
    public TextMeshProUGUI TomatoPriceText;
    public TextMeshProUGUI TomatoAmountText;
    public TextMeshProUGUI BlueberryPriceText;
    public TextMeshProUGUI BlueberryAmountText;
    public TextMeshProUGUI StrawberryPriceText;
    public TextMeshProUGUI StrawberryAmountText;
    public TextMeshProUGUI CowPriceText;
    public TextMeshProUGUI CowAmountText;
    public TextMeshProUGUI PlotPriceText;
    public TextMeshProUGUI PlotAmountText;
    public TextMeshProUGUI WorkerPriceText;
    public TextMeshProUGUI WorkerAmountText;
    public TextMeshProUGUI EquipmentPriceText;
    public TextMeshProUGUI EquipmentAmountText;

    [Header("Buttons")]
    public Button BuyTomatoButton;
    public Button BuyBlueberryButton;
    public Button BuyStrawberryButton;
    public Button BuyCowButton;
    public Button BuyPlotButton;
    public Button BuyWorkerButton;
    public Button BuyEquipmentButton;

    //Event
    public event Action OnBuyTomatoClicked;
    public event Action OnBuyBlueberryClicked;
    public event Action OnBuyStrawberryClicked;
    public event Action OnBuyCowClicked;
    public event Action OnBuyPlotClicked;
    public event Action OnBuyWorkerClicked;
    public event Action OnUpgradeEquipmentClicked;

    private void Awake()
    {
        BuyTomatoButton.onClick.AddListener(() => OnBuyTomatoClicked?.Invoke());
        BuyBlueberryButton.onClick.AddListener(() => OnBuyBlueberryClicked?.Invoke());
        BuyStrawberryButton.onClick.AddListener(() => OnBuyStrawberryClicked?.Invoke());
        BuyCowButton.onClick.AddListener(() => OnBuyCowClicked?.Invoke());
        BuyPlotButton.onClick.AddListener(() => OnBuyPlotClicked?.Invoke());
        BuyWorkerButton.onClick.AddListener(() => OnBuyWorkerClicked?.Invoke());
        BuyEquipmentButton.onClick.AddListener(() => OnUpgradeEquipmentClicked?.Invoke());
    }

    public void UpdateTomatoPrice(float price)
        => TomatoPriceText.text = price.ToString();

    public void UpdateTomatoAmount(int amount)
        => TomatoAmountText.text = amount.ToString();


    public void UpdateBlueberryPrice(float price)
        => BlueberryPriceText.text = price.ToString();

    public void UpdateBlueberryAmount(int amount)
        => BlueberryAmountText.text = amount.ToString();


    public void UpdateStrawberryPrice(float price)
        => StrawberryPriceText.text = price.ToString();

    public void UpdateStrawberryAmount(int amount)
        => StrawberryAmountText.text = amount.ToString();

    public void UpdateCowPrice(float price)
        => CowPriceText.text = price.ToString();

    public void UpdateCowAmount(int amount)
        => CowAmountText.text = amount.ToString();


    public void UpdatePlotPrice(float price)
        => PlotPriceText.text = price.ToString();

    public void UpdatePlotAmount(int amount)
        => PlotAmountText.text = amount.ToString();


    public void UpdateWorkerPrice(float price)
        => WorkerPriceText.text = price.ToString();

    public void UpdateWorkerAmount(int amount)
        => WorkerAmountText.text = amount.ToString();


    public void UpdateEquipmentPrice(float price)
        => EquipmentPriceText.text = price.ToString();

    public void UpdateEquipmentAmount(int amount)
        => EquipmentAmountText.text = amount.ToString();

}
