using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcCode : MonoBehaviour
{
    [SerializeField] purse purs;

    public float health;
    public bool isBounty = false;
    public bool isBountyClaimed = false;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (isBounty)
            {
                isBountyClaimed = true;
                Debug.Log(isBountyClaimed);
                purs.money += 20;
            }
            Destroy(gameObject);
        }

    }
}
