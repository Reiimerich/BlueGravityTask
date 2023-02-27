using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : NPCInteraction
{
    DisplayGold wallet;
    PlayerController player;

    public override void TriggerDialogue()
    {
        GiveGold();
    }
    
    //Give gold to the player when interacted or not, depends on the bool
    public void GiveGold()
    {
        if (canGiveGold)
        {
            wallet = FindObjectOfType<DisplayGold>();
            player = FindObjectOfType<PlayerController>();
            player.SetGold(150);
            wallet.CheckGold();
        }
        else
            print("This is a merchant... no free stuff");
    }
}
