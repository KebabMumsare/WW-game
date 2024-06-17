using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public bool canPickUp = false;
    bool pickedUpItem = false;

    string itemName = "";

    public Inventory2 inv;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            pickedUpItem = true;
        }
        if (pickedUpItem && itemName != null)
        {
            GameObject item = GameObject.Find(itemName);
            // other.gameObject.transform.parent.name
            inv.addToInventory(item);
            pickedUpItem = false;
            canPickUp = false;
            GameObject.Find(itemName).SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            itemName = other.gameObject.transform.parent.name;
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            canPickUp = false;
        }
    }
}
