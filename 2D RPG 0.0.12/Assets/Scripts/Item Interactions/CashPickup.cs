using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickup : MonoBehaviour
{
    public int value;
    private CashManager cashManager;


    // Start is called before the first frame update
    void Start()
    {
        cashManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CashManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {           
            cashManager.CashDialogueUpdate(value);
            gameObject.SetActive(false);
        }
    }
}
