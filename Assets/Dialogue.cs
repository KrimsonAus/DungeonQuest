using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [TextAreaAttribute(15,20)]
    public string DialogueText;
    public int DialogueSetID;
    public int DialogueID;
    public bool GiveItems;
    public GameObject[] ItemsToGive;
    public bool activateQuest;
    public Quest QuestToActivate;
    [Header("Requirements")]
    public bool RequireSpecificItem;
    public int[] ObjectsRequired;
    public bool RequireSpecificItemInHand;
    public int ObjectRequiredInHand;

    string textBackup;

    public void Start()
    {
        textBackup = DialogueText;
    }

    public void Update()
    {
        if(RequireSpecificItemInHand)
        {
            if (FindObjectOfType<Player>().ActiveItems[FindObjectOfType<Player>().InventorySelected].GetComponent<InventoryObject>().ID == ObjectRequiredInHand)
            {
                DialogueText = textBackup;
            }
            else
            {
                DialogueText = "Sorry but you dont have the required item, please return when you do.";
            }
        }
    }
}
