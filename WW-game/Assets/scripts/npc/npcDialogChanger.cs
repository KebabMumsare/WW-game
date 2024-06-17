using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class npcDialogChanger : MonoBehaviour
{
    public TextMeshProUGUI TMPText;

    public TextMeshProUGUI BTN1;
    public TextMeshProUGUI BTN2;
    public TextMeshProUGUI BTN3;
    // Texten som NPC:n ska säga
    public string text;
    public string alternativ1;
    public string alternativ2;
    public string alternativ3;
    // Start is called before the first frame update
    void Start()
    {
        if (TMPText != null) TMPText.text = text;
        if (BTN1 != null) BTN1.text = alternativ1;
        if (BTN2 != null) BTN2.text = alternativ2;
        if (BTN3 != null) BTN3.text = alternativ3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
