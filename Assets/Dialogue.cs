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
}
