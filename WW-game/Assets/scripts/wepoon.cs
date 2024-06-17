using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wepoon : MonoBehaviour
{
    [SerializeField] Inventory2 inv;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject blulet;

    bool isUpp;
    public bool semiAuto = false;
    bool hammerBack;

    public float bullets;
    public float cylinder;
    public float bulletSpeed;

    Vector3 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        
        cylinder = 6f;
        bullets = 6f;
        bulletSpeed = 50f;
        isUpp = false;
        hammerBack = false;
        gun.SetActive(isUpp);
    }

    // Update is called once per frame
    void Update()
    {
        shootDirection = Camera.main.transform.forward;

        if (inv.isInInventory("gun item"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (isUpp)
                {
                    isUpp = false;
                }
                else
                {
                    isUpp = true;
                }
                gun.SetActive(isUpp);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (hammerBack)
                {
                    actulyShoot();
                    hammerBack = false;
                }
                else
                {
                    hammerBack = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                reload();
            }
        }
        
    }
    void actulyShoot()
    {
        if (isUpp && cylinder >= 1)
        {
            GameObject newBlulet = Instantiate(blulet, barrel.transform.position, Quaternion.identity);
            newBlulet.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed, ForceMode.Impulse);

            cylinder -= 1;

        }
    }
    void reload()
    {
        if (bullets > 0 && cylinder < 6 && isUpp)
        {
            Debug.Log("Reloads gun");
            while (cylinder < 6 && bullets > 0)
            {
                cylinder++;
                bullets--;
            }
        }
    }
}
