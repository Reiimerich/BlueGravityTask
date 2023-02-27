using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private int totalGold;

    [SerializeField] NPCInteraction interactableNPC;

    Vector2 movement;

    private void Update()
    {
        Move();
        PlayerInteraction();
    }

    //Move the rigidbody of the player to allow him to move
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Use the animator BlendTree to display animations based on the direction the player is moving
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //Check if certain NPCS are in range 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Merchant>())
            interactableNPC = FindObjectOfType<Merchant>();

        if (collision.GetComponent<Bank>())
            interactableNPC = FindObjectOfType<Bank>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Merchant>() || collision.GetComponent<Bank>())
        {
            interactableNPC = null;
        }
    }

    private void PlayerInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactableNPC == null)
            {
                return;
            }
            else
            {
                interactableNPC.TriggerDialogue();
            }
        }
    }

    //Show the gold the player has at the moment
    public int GetGold()
    {
        return totalGold;
    }

    //Function to increase or decrease the player gold
    public void SetGold(int gold)
    {
        totalGold += gold;
    }
}
