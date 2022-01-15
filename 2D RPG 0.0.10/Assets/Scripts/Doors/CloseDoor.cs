using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public LockedDoor lockedDoorScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (lockedDoorScript.doorUnlocked == true)
            {
                if(gameObject.tag == "Outside Door")
                {
                    lockedDoorScript.OpenDoor();
                }
                else
                {
                    lockedDoorScript.CloseDoor();
                }
                
            }

        }
    }

}