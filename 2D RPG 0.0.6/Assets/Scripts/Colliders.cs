using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Colliders : MonoBehaviour
{
    public GameObject key;
    public int keysCollected;
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Key")
        {
            keysCollected += 1;
            key.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Locked Door")
        {
            if(keysCollected > 0)
            {
                door.gameObject.SetActive(false);

            }

        }
    }
}
