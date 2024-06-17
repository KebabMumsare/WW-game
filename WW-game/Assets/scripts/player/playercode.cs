using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Canvas inventoryCanvas;
    Canvas chestCanvas;
    Canvas npcDialogWindow;

    public bool gameStart;
    public bool canInteract;
    public bool canInteractNPC;

    public bool isInteracting;
    public bool isinteractingNPC;

    public Movement movementScript;

    GameObject häst;
    public GameObject player;
    public GameObject groundCheck;
    Transform horsePos;

    public bool isMounted;
    public bool canMountHorse;

    public Camera cam;



    void Start()
    {
        npcDialogWindow.enabled = false;
        chestCanvas.enabled = false;
        inventoryCanvas.enabled = false;
        canInteract = false;
        canInteractNPC = false;
        canMountHorse = false;
        
        gameStart = true;
        isinteractingNPC = false;
        isInteracting = false;
        isMounted = false;
    }

    void Update()
    {
        if(gameStart == true)
        {
            ToggleInventory();
            Debug.Log("inv state: " + inventoryCanvas.enabled);
            ToggleInventory();
            Debug.Log("inv state: " + inventoryCanvas.enabled);
            gameStart = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleChest();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            MountHorse();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleNPCUI();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "interact")
        {
            canInteract = true;
            chestCanvas = other.gameObject.GetComponentInChildren<Canvas>();
        }
        if (other.gameObject.tag == "NPC")
        {
            canInteractNPC = true;
            npcDialogWindow = other.gameObject.GetComponentInChildren<Canvas>();
        }
        if (other.gameObject.tag == "Häst")
        {
            canMountHorse = true;
            horsePos = other.gameObject.transform;
            häst = other.gameObject.transform.parent.gameObject;
            for (int i = 0; i < häst.transform.childCount; i++)
            {
                if (häst.transform.GetChild(i).name == "GroundCheck")
                {
                    movementScript.hastGroundCheck = häst.transform.GetChild(i);
                    break;
                }
            }
            Debug.Log(movementScript.hastGroundCheck.name);
            Debug.Log(häst.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "interact")
        {
            canInteract = false;
        }
        if (other.gameObject.tag == "NPC")
        {
            canInteractNPC = false;
        }
        if (other.gameObject.tag == "Häst")
        {
            canMountHorse = false;
        }
    }

    void ToggleInventory()
    {
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }
    void ToggleChest()
    {
        if (canInteract)
        {
            chestCanvas.enabled = !chestCanvas.enabled;
            isInteracting = !isInteracting;
        }
    }
    void ToggleNPCUI()
    {
        if (canInteractNPC && npcDialogWindow != null)
        {
            npcDialogWindow.enabled = !npcDialogWindow.enabled;
            isinteractingNPC = !isinteractingNPC;
            Debug.Log(isinteractingNPC);
        }    
    }

    void MountHorse()
    {
        if (canMountHorse)
        {
            if (isMounted)
            {
                // Detach the horse from the player
                Vector3 saddlePos = häst.transform.position;
                häst.transform.parent = null;
                Debug.Log("Player dismounted the horse.");
                Vector3 playerPos = player.transform.position;
                playerPos.y += 3.5f;
                isMounted = false;
                Vector3 horsePos = häst.transform.position;
                horsePos.y += 100f;
            }
            else
            {
                Vector3 saddlePos = häst.transform.position;
                saddlePos.y += 1f;
                player.transform.position = saddlePos;

                if (häst != null && player != null)
                {
                    Vector3 playerPos = player.transform.position;
                    playerPos.y += 100f;

                    häst.transform.SetParent(player.transform);
                    player.transform.position = playerPos;
                    Debug.Log(playerPos);
                    Debug.Log(player.transform.position);
                    isMounted = true;
                    movementScript.speed = 6f;
                    häst.transform.rotation = player.transform.rotation;
                }
            }
        }

    }
}