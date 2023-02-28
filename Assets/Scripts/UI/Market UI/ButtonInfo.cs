using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public TextMeshProUGUI priceTxt;
    public TextMeshProUGUI itemName;
    public int itemID;

    ShopManager shopManager;

    private void Start()
    {
        shopManager = FindObjectOfType<ShopManager>();
    }

    void Update()
    {
        priceTxt.text = "Price: $ " + shopManager.shopItems[2,itemID].ToString();
    }
}
