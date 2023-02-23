using UnityEngine;

[System.Serializable]
public class inventoryHandler : MonoBehaviour
{
    
    //---------VARIABLES---------//
    //public List<Item> playerInventory = new List<Item>();
    public static int inventorySpace = 27;
    public Item[] playerInventory = new Item[inventorySpace];
    [SerializeField] public SpriteRenderer[] inventorySlots = new SpriteRenderer[inventorySpace];

    public GameObject inventoryHandlerObject;

    public playerInteract playerInteractScript;
    public Item itemScript;

    public bool inventoryOpen = false;
    //---------FUNCTIONS---------//
    void Start()
    {
        inventoryHandlerObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab)) openInventory();
    }

    public void openInventory()
    {
        if (!playerInteractScript.isInteracting && !inventoryOpen)
        {
            inventoryHandlerObject.SetActive(true);
            playerInteractScript.isInteracting = true;
            inventoryOpen = true;
            
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (playerInventory[i] != null)
                {
                    inventorySlots[i].gameObject.SetActive(true);
                    inventorySlots[i].sprite = playerInventory[i].icon;
                }
                else
                {
                    inventorySlots[i].gameObject.SetActive(false);
                }
            }
        }
    }


    public void addItem(GameObject item)
    {
        for (int i = 0; i < playerInventory.Length; i++)
        {
            if (playerInventory[i] == null && item != null)
            {
                Item newItem = new Item(item.name, item.GetComponent<SpriteRenderer>().sprite);
                Debug.Log(newItem);
                playerInventory[i] = newItem;
                Destroy(item);
                break;
            }
        }
    }
}
