using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject HandHoldPos;
    public int InventorySelected;
    public GameObject[] Items;
    public GameObject[] ActiveItems;
    bool ItemActive;

    bool off;
    float offtimer;

    public GameObject CamPos;

    public GameObject Nothing;
    // Start is called before the first frame update
    void Start()
    {
        ActiveItems = new GameObject[Items.Length];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(2))
        {
            CamPos.transform.Rotate(-Input.GetAxis("Mouse Y")*5,0, 0);
#pragma warning disable CS0618
            CamPos.transform.RotateAround(transform.up, Input.GetAxis("Mouse X") / 10);
#pragma warning restore CS0618
        }

        Camera.main.transform.position += Camera.main.transform.forward * Input.mouseScrollDelta.y;

        if (InventorySelected >= Items.Length)
        {
            InventorySelected = 0;
        }
        if (!off)
        {
            offtimer+=Time.deltaTime;

            if (offtimer >= 0.01f)
            {
                GameObject.FindGameObjectWithTag("Dialogue").SetActive(false);
                off = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.tag == "Ground")
                {
                    GetComponent<NavMeshAgent>().destination = hit.point;
                }
            }
        }

        if (!ItemActive)
        {
            ActiveItems[InventorySelected] = Instantiate(Items[InventorySelected], HandHoldPos.transform);
            ItemActive = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(ActiveItems[InventorySelected]);
            InventorySelected += 1;
            ItemActive=false;
        }
    }
}
