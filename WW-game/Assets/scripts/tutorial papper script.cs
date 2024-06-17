using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialpapperscript : MonoBehaviour
{
    [SerializeField] Inventory2 inv;
    bool isUpp;
    public GameObject tutorialPapperInv; 

    void Start()
    {
        isUpp = false;
        tutorialPapperInv.SetActive(isUpp);
    }

    void Update()
    {
        if (inv.isInInventory("tutorial_papper"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                isUpp = !isUpp;
                tutorialPapperInv.SetActive(isUpp);
            }
        }
    }
}
