using UnityEngine;

public class ItemsRegistry : MonoBehaviour
{
    public GameObject COIN;
    public GameObject APPLE;


    public Item gameObjectToItem(GameObject go)
    {
        Item newItem = new Item(go.name, go.GetComponent<SpriteRenderer>().sprite);
        return newItem;
    }
}
