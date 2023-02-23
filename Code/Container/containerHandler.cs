using System;
using System.Collections.Generic;
using UnityEngine;

public class containerHandler : MonoBehaviour
{
    public bool containerOpen = false;
    public GameObject containerHandlerObject;

    public static int inventorySpace = 27;
    public Item[] containerInventory = new Item[inventorySpace];
    [SerializeField] public SpriteRenderer[] inventorySlots = new SpriteRenderer[inventorySpace];

    public List<GameObject> alreadyOpened = new List<GameObject>();

    private void Start()
    {
        containerHandlerObject.SetActive(false);
    }

    public void openContainer(GameObject container)
    {
        if (GetComponent<playerInteract>().isInteracting && !containerOpen && !alreadyOpened.Contains(container))
        {
            //set window visible
            containerHandlerObject.SetActive(true);
            GetComponent<playerInteract>().isInteracting = true;
            containerOpen = true;

            //add barrel to opened list
            alreadyOpened.Add(container);
        }
        else
        {
            GetComponent<playerInteract>().isInteracting = false;
        }
    }
}
