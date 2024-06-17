using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float dmg = 10f;
    public float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Timer till skottet
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC Body")
        {
            collision.gameObject.GetComponent<npcCode>().health -= dmg;
        }
        Destroy(gameObject);
    }
}
