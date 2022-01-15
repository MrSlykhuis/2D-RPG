using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite unlockedSprite;
    public Sprite emptySprite;

    public Collider2D doorCollider;

    private Inventory inventory;
    public bool doorUnlocked;
    private GameObject player;
    public bool doorOpen;


    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (doorUnlocked)
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
        if (inventory.keysCollected >= 1 && !doorUnlocked)
        {
            doorUnlocked = true;
            inventory.keysCollected -= 1;
            OpenDoor();
        }
    }
}
