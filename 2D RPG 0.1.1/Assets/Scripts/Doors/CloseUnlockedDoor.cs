using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUnlockedDoor : MonoBehaviour
{
    OpenDoorScript openDoorScript;


    private void Start()
    {
        openDoorScript = GetComponentInParent<OpenDoorScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            openDoorScript.CloseDoor();
        }
    }
}
