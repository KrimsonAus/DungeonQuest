using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Character : MonoBehaviour
{
    public GameObject[] Char;
    public int Selected;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Selected >= Char.Length)
        {
            Selected = 0;
        }
        for (int i = 0; i < Char.Length; i++)
        {
            Char[i].SetActive(false);
        }
        Char[Selected].SetActive(true);
    }
}
