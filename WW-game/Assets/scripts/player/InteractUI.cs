using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public Player player;
    public PickUpItems pickUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.canInteract)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Interact";
        }
        else if (player.canInteractNPC)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Talk";
        }
        else if (player.canMountHorse)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Mount";
        }
        else if (pickUp.canPickUp)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Pick Up";
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
