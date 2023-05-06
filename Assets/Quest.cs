using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [Header("Base Settings")]
    public int ID;
    [TextAreaAttribute(5, 10)]
    public string QuestDescription;

    public int Type;

    [Header("Type Specific")]
    public GameObject ObjectToDestroy;
    [Space(5)]
    public GameObject EnemyToAttack;
    [Space(5)]
    public GameObject ObjectToInteractWith;

    [Space(10)]
    [Header("After Quest Compeletion")]
    public bool DialogueSetPlus;

    public NPC NPCToSetPlus;
    [HideInInspector] public bool Completed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Type == 0 && ObjectToDestroy != null)
        {
            if (ObjectToDestroy.GetComponent<WorldObject>().Health <= 0)
            {
                Destroy(ObjectToDestroy);
                ObjectToDestroy = null;
            }
        }

        if (Completed)
        {
            if (DialogueSetPlus)
            {
                NPCToSetPlus.set += 1;
                DialogueSetPlus = false;
                NPCToSetPlus.UpdateSetArray();
                NPCToSetPlus.Dialogue = true;
            }
        }
    }
}
