using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class NPC : MonoBehaviour
{
    public bool Dialogue;
    [HideInInspector] public GameObject Diag;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public TMPro.TextMeshProUGUI DiagText;
    public GameObject[] Dialogues;
    public GameObject[] SetDialogues;
    bool DialogueActive;
    public int set=0;
    public int id=0;
    public Dialogue ActiveDialogue;
    int noofsets;
    int earliestSet=999;
    // Start is called before the first frame update
    void Start()
    {
        Diag = GameObject.FindGameObjectWithTag("Dialogue");
        DiagText = Diag.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        Player = GameObject.FindGameObjectWithTag("Player");
        SetDialogues = new GameObject[Dialogues.Length];

        UpdateSetArray();
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveDialogue != null && DialogueActive)
        {
            DiagText.text = ActiveDialogue.DialogueText;
        }

    }
    private void OnMouseDown()
    {
        print(gameObject.name + " is pressed");
        if (Dialogue)
        {
            if (id != SetDialogues.Length - 1)
            {
                if (DialogueActive)
                {
                    id += 1;
                }
            }
            else
            {
                id = 0;
                DialogueActive = false;
                Dialogue = false;
                Diag.SetActive(false);
            }
            if (!DialogueActive && Dialogue)
            {
                Diag.SetActive(true);
                DialogueActive = true;
            }
            ActiveDialogue = Dialogues[id].GetComponent<Dialogue>();

            if (ActiveDialogue != null)
            {
                if (ActiveDialogue.GiveItems)
                {
                    print("Should Give Items");
                    for (int i = 0; i < ActiveDialogue.ItemsToGive.Length; i++)
                    {
                        print("Giving Items");
                        Player.GetComponent<Player>().Items[Player.GetComponent<Player>().Items.Length - 1] = ActiveDialogue.ItemsToGive[i];
                        GameObject[] lst;
                        lst = new GameObject[Player.GetComponent<Player>().Items.Length];
                        lst = Player.GetComponent<Player>().Items;
                        Player.GetComponent<Player>().Items = new GameObject[Player.GetComponent<Player>().Items.Length + 1];

                        for (int k = 0; k < lst.Length; k++)
                        {
                            Player.GetComponent<Player>().Items[k] = lst[k];
                        }
                        Player.GetComponent<Player>().Items[Player.GetComponent<Player>().Items.Length-1] = Player.GetComponent<Player>().Nothing;
                        Player.GetComponent<Player>().ActiveItems = new GameObject[Player.GetComponent<Player>().Items.Length];
                    }
                }
            }
        }
    }

    public void UpdateSetArray()
    {
        earliestSet = 999;
        SetDialogues = new GameObject[0];
        SetDialogues = new GameObject[Dialogues.Length];
        for (int i = 0; i < Dialogues.Length; i++)
        {
            if (set == Dialogues[i].GetComponent<Dialogue>().DialogueSetID)
            {
                if (earliestSet==999)
                {
                    earliestSet = i;
                }
                noofsets += 1;
                SetDialogues[i] = Dialogues[i];
            }
        }

        SetDialogues = new GameObject[noofsets];
        for (int i = earliestSet; i < noofsets; i++)
        {
            SetDialogues[i] = Dialogues[i];
        }
    }
}
