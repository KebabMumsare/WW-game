using UnityEngine;
using UnityEngine.UI;

public class BuyItemButton : MonoBehaviour
{
    public GameObject item;
    public GameObject itemSpawn;

    public purse money;

    int price1 = 10;
    int price2 = 20;
    int price3 = 30;


    void Start()
    {

        Button button1 = GameObject.Find("Button1").GetComponent<Button>();
        Button button2 = GameObject.Find("Button2").GetComponent<Button>();
        Button button3 = GameObject.Find("Button3").GetComponent<Button>();

        button1.onClick.AddListener(BuyItem1);
        button2.onClick.AddListener(BuyItem2);
        button3.onClick.AddListener(BuyItem3);
    }

    public void BuyItem1()
    {
        if (money.money >= price1) 
        {
            money.money -= price1;
            Instantiate(item, itemSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Du har igge peng");
        }
    }

    public void BuyItem2()
    {
        if (money.money >= price2)
        {
            money.money -= price2;
            Debug.Log("Du har betalat 20 dollars");
        }
        else
        {
            Debug.Log("Du har igge peng");
        }
    }

    public void BuyItem3()
    {
        if (money.money >= price3)
        {
            money.money -= price3;
            Debug.Log("Du har betalat 30 dollars");
        }
        else
        {
            Debug.Log("Du har igge peng");
        }
    }
}
