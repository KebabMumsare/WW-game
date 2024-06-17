using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moenyUI : MonoBehaviour
{
    public purse money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (money != null)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = money.money + "$";
        }
    }
}
