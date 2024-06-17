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
    [HideInInspector] public string text;
    [HideInInspector] public string alternativ1;
    [HideInInspector] public string alternativ2;
    [HideInInspector] public string alternativ3;

    public string defText;
    public string defAlternativ1;
    public string defAlternativ2;
    public string defAlternativ3;
    // Start is called before the first frame update
    void Start()
    {
        text = defText;
        alternativ1 = defAlternativ1;
        alternativ2 = defAlternativ2;
        alternativ3 = defAlternativ3;
    }

    // Update is called once per frame
    void Update()
    {
        if (TMPText != null) TMPText.text = text;
        if (BTN1 != null) BTN1.text = alternativ1;
        if (BTN2 != null) BTN2.text = alternativ2;
        if (BTN3 != null) BTN3.text = alternativ3;
    }
}
