using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public int keysCollected;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Key")
        {
            GameObject key = collision.gameObject;
            Debug.Log("hit the key");
            keysCollected += 1;
            key.gameObject.SetActive(false);
        }
    }

}
