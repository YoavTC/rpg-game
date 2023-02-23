using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class chatHandler : MonoBehaviour
{
    //---------Maps---------//
    public Dictionary<GameObject, int> conversationNumber = new Dictionary<GameObject, int>();
    //---------Variables---------//
    public GameObject chatHandlerGoGameObject;
    public playerInteract playerInteractScript;

    public SpriteRenderer newRenderer;
    public Text textBox;
    public int numOfMsg = 0;
    public float typingSpeed = 20f;

    public JArray array;
    public JObject obj;

    //---------Default Functions---------//
    void Start()
    {
        chatHandlerGoGameObject.SetActive(false);
    }

    //---------Functions---------//

    //opens the chat with an NPC defined as chatter
    public void StartChat(GameObject chatter)
    {
        //make chat visible
        chatHandlerGoGameObject.SetActive(true);

        //get NPC sprite
        newRenderer.sprite = chatter.GetComponent<SpriteRenderer>().sprite;
        
        //get NPC's dialogue file
        obj = JObject.Parse(File.ReadAllText("Assets/npc-text/"+chatter.name+".json")); 
        
        //increase the index of conversation by 1
        obj["conversation"] = (int)obj["conversation"] + 1;

        //get NPC's current conversation
        int temp = (int) obj["conversation"];
        array = (JArray)obj[temp.ToString()];

        if (temp.ToString() == obj.Properties().Last().Name)
        {
            obj["conversation"] = 0;
        }
        
        //rewirte the json file with the updated information
        string jsonString = JsonConvert.SerializeObject(obj,Formatting.Indented);
        File.WriteAllText("Assets/npc-text/"+chatter.name +".json", jsonString);
        
        //visualize text
        WriteText();
    }
    public void WriteText() //button also calls this function!
    {
        StopAllCoroutines();
        textBox.text = "";

        try
        {
            StartCoroutine(TypeText(GetLine(numOfMsg)));
        }
        catch
        {
            StopChat();
        }
    }

    public IEnumerator TypeText(string text)
    {
        text = text.ToUpper();
        foreach (char letter in text)
        {
            textBox.text += letter;
            yield return new WaitForSeconds(1 / typingSpeed);
        }
    }
    public string GetLine(int i) //get the next line the textbox should display
    {
        string nextLine = (string)array[i];
        numOfMsg++;
        return nextLine;
    }

    public void StopChat()
    {
        chatHandlerGoGameObject.SetActive(false);
        playerInteractScript.isInteracting = false;
        numOfMsg = 0;
    }
}
