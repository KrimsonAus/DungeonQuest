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
    }
}
