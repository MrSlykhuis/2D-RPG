using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite unlockedSprite;
    public Sprite emptySprite;

    public Collider2D doorCollider;

    public KeyManager keyManager;
    private GameObject gameManager;
    private GameObject player;
    public bool doorOpen;

    //this links to the LockManager so that door knows which one it is.
    public bool doorUnlocked;//this is dropped from the LockManager
    public LockManager lockManager;
    public int i; //this is the ID of each door which is logged in the LockManager


    public void Awake()
    {
        keyManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<KeyManager>();
        lockManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LockManager>();
        {
            if (lockManager.doorUnlocked[i] == true)
            {
                CloseDoor();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (lockManager.doorUnlocked[i]==true)
            {
                OpenDoor();
            }
            else
            {
                UnlockDoor();
            }
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = emptySprite;
        doorCollider.isTrigger = true;
        doorOpen = true;
    }

    public void CloseDoor()
    {
        spriteRenderer.sprite = unlockedSprite;
        doorCollider.isTrigger = false;
        doorOpen = false;
    }

    public void UnlockDoor()
    {
        Debug.Log("test");
        if (keyManager.keysCollected >= 1 && lockManager.doorUnlocked[i] == false)
        {
            Debug.Log("LockedDoorTest");
            lockManager.doorUnlocked[i] = true;
            keyManager.keysCollected -= 1;
            keyManager.KeyDialogueUpdate();
            OpenDoor();
        }
    }
}
