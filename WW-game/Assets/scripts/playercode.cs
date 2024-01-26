using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InventoryItem[] inventoryItems;
    public Canvas menuCanvas;
    public Text inventoryText;

    void Start()
    {
        inventoryItems = new InventoryItem[5];
        inventoryItems[0] = new InventoryItem { itemName = "intropapper", player = gameObject, quantity = 1 };

        // Assuming you have a Canvas in your scene
        menuCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        menuCanvas.enabled = !menuCanvas.enabled;

        if (menuCanvas.enabled)
        {
            UpdateInventoryText();
        }
    }

    void UpdateInventoryText()
    {
        // Update the UI Text with inventory information
        string inventoryInfo = "Inventory:\n";
        foreach (InventoryItem item in inventoryItems)
        {
            if (item != null)
            {
                inventoryInfo += item.itemName + " - " + item.quantity + "\n";
            }
        }
        inventoryText.text = inventoryInfo;
    }

    public void AddItemToInventory(string itemName, int amount = 1)
    {
        InventoryItem item = FindItem(itemName);

        if (item != null)
        {
            item.quantity += amount;
            Debug.Log("Added " + amount + " " + itemName + "(s) to the inventory.");
            if (menuCanvas.enabled)
            {
                UpdateInventoryText();
            }
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
