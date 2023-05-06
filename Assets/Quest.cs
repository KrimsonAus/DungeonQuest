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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
