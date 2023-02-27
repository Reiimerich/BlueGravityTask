using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public TextMeshProUGUI costTxt;
    public int coins;

    PlayerController player;
    DisplayGold wallet;

    void Start()
    {
        costTxt.text = "$ " + coins;

        //Set ID for items in the store to identify them on the array
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Set the price for the items in the store based on their ID
        shopItems[2, 1] = 40;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 333;
        shopItems[2, 4] = 442;

    }


    public void Buy()
    {
        //Get references for player gold and their wallet
        player = FindObjectOfType<PlayerController>();
        wallet = FindObjectOfType<DisplayGold>();
        int playerMoney = player.GetGold();

        //Interact when the button has been pressed to identify each one
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Item").GetComponent<EventSystem>().currentSelectedGameObject;

        if(playerMoney > shopItems[2,buttonRef.GetComponent<ButtonInfo>().itemID])
        {
            //Create calculus to reduce the player money and update on the UI
            player.SetGold(-shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID]);
            wallet.CheckGold();
        }
    }
}
