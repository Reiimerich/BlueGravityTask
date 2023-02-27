using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactionPopUp;
    [SerializeField] GameObject dialoguePanel;

    public Dialogue dialogue;
    public bool canGiveGold;
    
    //Interaction when the player is in Range (Circle Collider2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
            interactionPopUp.SetActive(true);
    }

    //Interaction when the player is leaves (Circle Collider2D)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            interactionPopUp.SetActive(false);
        }
    }

    public virtual void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
