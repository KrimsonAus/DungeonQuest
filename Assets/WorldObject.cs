using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public bool Destroyable;
    public bool Interactable;
    public int Health;
    public GameObject[] ResourcesToGive;
    public bool RequireSpecificItem;
    public int[] ObjectsRequired;
    public bool RequireSpecificItemInHand;
    public int ObjectRequiredInHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, FindObjectOfType<Player>().transform.position)<5)
        {
            if (!RequireSpecificItem && !RequireSpecificItemInHand)
            {
                Health -= 1;
            }
            if (RequireSpecificItemInHand && !RequireSpecificItem)
            {
                if (FindObjectOfType<Player>().ActiveItems[FindObjectOfType<Player>().InventorySelected].GetComponent<InventoryObject>().ID == ObjectRequiredInHand)
                {
                    Health -= 1;
                }
            }
        }
    }
}
