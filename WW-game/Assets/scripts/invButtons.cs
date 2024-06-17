using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class buttonUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject panel;
    public Inventory2 inv;
    TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        buttonText = buttonPrefab.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInventory();
    }

    public void updateInventory()
    {
        if (inv != null)
        {
            for (int i = 0; i < inv.itemsInventory.Length; i++)
            {
                if (inv.itemsInventory[i] != null && !inv.itemsInventory[i].gameObject.GetComponent<Item>().stored)
                {
                    buttonText.text = inv.itemsInventory[i].name;
                    // Instantiate a new buttonPrefab
                    GameObject newButton = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);

                    // Set the parent of the new instance to the panel
                    newButton.transform.SetParent(panel.transform);
                    // Mark the item as stored
                    inv.itemsInventory[i].gameObject.GetComponent<Item>().stored = true;
                    Debug.Log("kanpp ska läggas till");
                }
            }
        }
    }
}
