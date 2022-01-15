using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    private KeyManager keyManager;

    // Start is called before the first frame update
    void Start()
    {
        keyManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<KeyManager>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        {

            if (collision.gameObject.tag == "Player")
            {
                keyManager.keysCollected += 1;
                keyManager.KeyDialogueUpdate();
                gameObject.SetActive(false);
            }
        }
    }

}
