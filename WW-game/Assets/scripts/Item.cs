using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int amount = 1;
    string itemName;
    GameObject obj;
    public bool stored = false;

    // Start is called before the first frame update
    void Start()
    {
        itemName = name;
        obj = GameObject.Find(itemName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
