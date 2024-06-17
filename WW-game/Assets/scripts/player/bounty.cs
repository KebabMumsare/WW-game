using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounty : MonoBehaviour
{
    [SerializeField] Inventory2 inv;
    [SerializeField] purse purs;
    npcCode npc;
    [SerializeField] GameObject bountyBill;

    GameObject[] npcs;
    int npcCount = 0;
    int randomNPC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (npc != null)
        {
            
            if (npcs[npcCount-1].name != "Sheriff")
            {
                if (inv.isInInventory("bountyPapper"))
                {
                    npc.isBounty = true;
                    Debug.Log(npc.name);
                    Debug.Log(npc.isBounty);
                }
            }
            else
            {
                acceptBounty();
            }
        }
        
    }
    
    public void acceptBounty()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC Body");
        foreach (GameObject num in npcs)
        {
            npcCount++;
        }
        randomNPC = Random.Range(0, npcCount);
        npc = npcs[randomNPC].GetComponent<npcCode>();
        Debug.Log(npcs[randomNPC].name);
        inv.addToInventory(bountyBill);
    }
}
