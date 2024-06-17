using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMission : MonoBehaviour
{
    [SerializeField] npcDialogChanger dc;
    [SerializeField] purse money;
    [SerializeField] Inventory2 inv;

    bool newddlg = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!newddlg)
        {
            dc.text = "God dag, hade du kunnat hjälpa mig med en sak?";
            dc.alternativ1 = "Ja";
            dc.alternativ2 = "Nej";
        }
    }
    public void buttonPress()
    {
        if (!newddlg)
        {
            accept();
        }
        else
        {
            redeem();
        }
    }
    public void accept()
    {
        dc.text = "Perfekt, jag hade velat att du skulle köpa en revolver till mig, du får 20$";
        newddlg = true;
        Debug.Log("Acceptera");
    }
    public void redeem()
    {
        if (money != null && inv != null)
        {
            if (inv.isInInventory("gun item"))
            {
                dc.text = "Tack så mycket, här har du dina 20$";
                money.money += 20;
            }
            else
            {
                Debug.Log("Har inte gun item i inventory");
            }
        }
        else
        {
            Debug.Log("Purse.cs eller iventory2.cs");
        }
        
    }
}
