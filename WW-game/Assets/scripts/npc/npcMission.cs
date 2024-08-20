using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMission : MonoBehaviour
{
    [SerializeField] npcDialogChanger npcDC;
    [SerializeField] purse money;
    // Start is called before the first frame update
    void Start()
    {
        if (npcDC != null)
        {
            npcDC.text = "Vill du ha ett updrag";
            npcDC.alternativ1 = "Acceptera";
            npcDC.alternativ2 = "Neka";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void acceptMission()
    {
        npcDC.text = "Kan du köpa en revolver till mig";
        npcDC.alternativ1 = "Jag fixar";
        npcDC.alternativ2 = "Nej";
    }
    public void denyMission()
    {
        npcDC.text = "Du luktar kiss";
        npcDC.alternativ1 = "Hur viste du";
        npcDC.alternativ2 = "Nej";
    }
}
