using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public LockedDoor lockedDoorScript;
    private LockManager lockManager;
    public int i;

    private void Start()
    {
        lockManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LockManager>();
        lockedDoorScript = GetComponentInParent<LockedDoor>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (lockManager.doorUnlocked[i] == true)

            {
                lockedDoorScript.OpenDoor();
            }

            else
            {
                lockedDoorScript.UnlockDoor();
            }

        }
    }

}