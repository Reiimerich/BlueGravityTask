using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class DisplayGold : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;

    private void Awake()
    {
        CheckGold();
    }

    public void CheckGold()
    {
        //Display the gold the player has
        int actualGold = FindObjectOfType<PlayerController>().GetGold();
        goldText.text = actualGold.ToString();
    }
}
