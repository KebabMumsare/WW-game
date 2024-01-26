using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string itemName;
    public GameObject player; 
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    public InventoryItem[] items;
    public GameObject player; 

    void Start()
    {
        items = new InventoryItem[5];
        items[0] = new InventoryItem { itemName = "intropapper", player = player, quantity = 1 };
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    public void AddItem(string itemName, int amount = 1)
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
        foreach (InventoryItem item in items)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
