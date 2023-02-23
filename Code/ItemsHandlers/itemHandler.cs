using System;
using UnityEngine;

public class itemHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<inventoryHandler>().addItem(gameObject);
        }
    }
}
