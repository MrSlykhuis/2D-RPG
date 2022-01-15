using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public GameObject key;
    public int keysCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Key")
        {
            keysCollected += 1;
            key.gameObject.SetActive(false);
        }
    }

}
