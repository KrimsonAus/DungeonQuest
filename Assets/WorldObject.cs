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
    public GameObject[] ObjectsRequired;
    public bool RequireSpecificItemInHand;
    public GameObject ObjectsRequiredInHand;
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
        if (!RequireSpecificItem)
        {
            Health -= 1;
        }
        else
        {
            if (FindObjectOfType<Player>().ActiveItems[FindObjectOfType<Player>().InventorySelected] == ObjectsRequiredInHand)
            {
                Health -= 1;
            }
        }
    }
}
