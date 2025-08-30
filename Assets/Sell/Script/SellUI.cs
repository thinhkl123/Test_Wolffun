using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellUI : UICanvas
{
    [Header("Price Text")]
    public TextMeshProUGUI TomatoPriceText;
    public TextMeshProUGUI BlueberryPriceText;
    public TextMeshProUGUI StrawberryPriceText;
    public TextMeshProUGUI MilkPriceText;

    [Header("Amount Text")]
    public TextMeshProUGUI TomatoAmountText;
    public TextMeshProUGUI BlueberryAmountText;
    public TextMeshProUGUI StrawberryAmountText;
    public TextMeshProUGUI MilkAmountText;

    [Header(" Button ")]
    public Button SellTomatoButton;
    public Button SellBlueberryButton;
    public Button SellStrawberryButton;
    public Button SellMilkButton;

    //Event
    public event Action OnSellTomatoClicked;
    public event Action OnSellBlueberryClicked;
    public event Action OnSellStrawberryClicked;
    public event Action OnSellMilkClicked;

    private void Awake()
    {
        SellTomatoButton.onClick.AddListener(() => OnSellTomatoClicked?.Invoke());
        SellBlueberryButton.onClick.AddListener(() => OnSellBlueberryClicked?.Invoke());
        SellStrawberryButton.onClick.AddListener(() => OnSellStrawberryClicked?.Invoke());
        SellMilkButton.onClick.AddListener(() => OnSellMilkClicked?.Invoke());
    }

    public void UpdateTomatoPrice(float price) 
    { 
        TomatoPriceText.text = price.ToString(); 
    }
    public void UpdateBlueberryPrice(float price)
    {
        BlueberryPriceText.text = price.ToString();
    }

    public void UpdateStrawberryPrice(float price)
    {
        StrawberryPriceText.text = price.ToString();
    }

    public void UpdateMilkPrice(float price)
    {
        MilkPriceText.text = price.ToString();
    }

    public void UpdateTomatoAmount(int value)
    {
        TomatoAmountText.text = value.ToString();
    }

    public void UpdateBlueberryAmount(int value)
    {
        BlueberryAmountText.text = value.ToString();
    }

    public void UpdateStrawberryAmount(int value)
    {
        StrawberryAmountText.text = value.ToString();
    }

    public void UpdateMilkAmount(int value)
    {
        MilkAmountText.text = value.ToString();
    }
}
