using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryItem[] inventoryItems;

    void Start()
    {
        inventoryItems = new InventoryItem[5];
        inventoryItems[0] = new InventoryItem { itemName = "intropapper", player = gameObject, quantity = 1 };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddItemToInventory("SomeItem", 3);
        }
    }

    public void AddItemToInventory(string itemName, int amount = 1)
    {
        InventoryItem item = FindItem(itemName);

        if (item != null)
        {
            item.quantity += amount;
            Debug.Log("Added " + amount + " " + itemName + "(s) to the inventory.");
        }
        else
        {
            Debug.LogWarning("Item " + itemName + " not found in the inventory.");
        }
    }

    private InventoryItem FindItem(string itemName)
    {
        foreach (InventoryItem item in inventoryItems)
        {
            if (item != null && item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }


}
