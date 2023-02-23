using System;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    //---------Variables---------//
    public GameObject player;
    public bool canInteract = false;
    public bool isInteracting = false;
    public GameObject interactedWith;
    public chatHandler chatHandlerScript;

    public GameObject containerHandler;
    public GameObject inventoryHandler;

    public chestHandler chestHandlerScript;
    //---------Functions---------//
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) checkInteract();
        if (Input.GetKey(KeyCode.Escape)) closeInterface();
    }
    
    private void checkInteract()
    {
        if (canInteract && !isInteracting && interactedWith.gameObject.CompareTag("Npc")) //START INTERACTION
        {
            chatHandlerScript.StartChat(interactedWith);
            isInteracting = true;
        }
        if (canInteract && !isInteracting && interactedWith.gameObject.CompareTag("Chest")) //OPEN CHEST
        {
            isInteracting = true;
            chestHandlerScript.openChest(interactedWith);
        }
        if (canInteract && !isInteracting && interactedWith.gameObject.CompareTag("Container")) //OPEN CONTAINER
        {
            isInteracting = true;
            GetComponent<containerHandler>().openContainer(interactedWith);
        }
    }
    public void closeInterface()
    {
        if (isInteracting && GetComponent<inventoryHandler>().inventoryOpen)
        {
            isInteracting = false;
            inventoryHandler.SetActive(false);
            GetComponent<inventoryHandler>().inventoryOpen = false;
        }

        if (isInteracting && GetComponent<containerHandler>().containerOpen)
        {
            isInteracting = false;
            containerHandler.SetActive(false);
            GetComponent<containerHandler>().containerOpen = false;
        }
    }
    //---------2D Checks---------//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Npc") || collision.gameObject.CompareTag("Container") || collision.gameObject.CompareTag("Chest"))
        {
            canInteract = true;
            interactedWith = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract= false;
        interactedWith = null;
        isInteracting = false;
    }
}
