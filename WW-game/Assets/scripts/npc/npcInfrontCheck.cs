using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInfrontCheck : MonoBehaviour
{
    public npcMovement npcMov;

    // Called when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");
        npcMov.canMoveForward = false;
    }

    // Called when something exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Not Colliding");
        npcMov.canMoveForward = true;
    }

    void Update()
    {
        
    }
}