using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int[] QuestIDs;
    public int ActiveQuestID;
    public GameObject[] Quests;
    public bool ActiveQuestCompleted;

    Quest ActiveQuestQuestComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActiveQuestQuestComponent = Quests[ActiveQuestID].GetComponent<Quest>();
        if (ActiveQuestQuestComponent.Type == 0)
        {
            if(ActiveQuestQuestComponent.ObjectToDestroy == null)
            {
                ActiveQuestCompleted=true;
                ActiveQuestQuestComponent.Completed = true;
            }
        }

    }
}
