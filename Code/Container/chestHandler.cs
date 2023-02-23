using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class chestHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject item;
    public GameObject chestHandlerGameObject;
    public SpriteRenderer newRenderer;
    public Text textBox;

    private void Start()
    {
        chestHandlerGameObject.SetActive(false);
    }

    
    //TODO
    //1. FIX ITEM ICON SPRITE RENDERING ISSUE
    
    
    public void openChest(GameObject chest)
    {
        Debug.Log("openChest()");
        //start visuals
        chestHandlerGameObject.SetActive(true);

        //spawn item
        Instantiate(item, chest.transform.position, chest.transform.rotation);
        
        
        newRenderer.sprite = item.GetComponent<SpriteRenderer>().sprite;
        textBox.text = (item.name + " Found!").ToUpper();
        
        Destroy(chest);
        StartCoroutine(CloseChest(chest));
    }

    private IEnumerator CloseChest(GameObject chest)
    {
        yield return new WaitForSeconds(1.5f);
        chestHandlerGameObject.SetActive(false);
        player.GetComponent<playerInteract>().isInteracting = false;
    }
}
