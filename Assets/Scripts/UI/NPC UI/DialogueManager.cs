using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject decisionPanel;
    public GameObject dialogueButton;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public Animator animator;

    private Queue<string> sentences;
    bool alreadyInteracted;


    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        decisionPanel.SetActive(false);
        dialogueButton.SetActive(true);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Check if the player already came in contact with the NPC to prevent text bugs
        if (!alreadyInteracted)
        {
            alreadyInteracted = true;
            dialoguePanel.SetActive(true);
            animator.SetBool("IsOpen", true);

            nameText.text = dialogue.name;
            sentences.Clear();

            //To reproduce each sentence in the array following an order
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        else
            return;
    }

    public void DisplayNextSentence()
    {
        //To display the decision panel before ending the conversation with the NPC
        if (sentences.Count == 1)
        {
            decisionPanel.SetActive(true);
            dialogueButton.SetActive(false);
        }

        if (sentences.Count == 0) 
        {
            EndDialogue();
            decisionPanel.SetActive(false);
            dialogueButton.SetActive(true);
            return;
        }
        
        //Display the line and remove it from the queue after being displayed
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        alreadyInteracted = false;
    }
    
}
