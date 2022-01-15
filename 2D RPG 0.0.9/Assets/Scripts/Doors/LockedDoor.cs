using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite unlockedSprite;
    public Sprite emptySprite;
    public GameObject fogOfWar;
    public GameObject fogOfWarInside;

    public Collider2D doorCollider;

    public Inventory inventory;
    public bool doorUnlocked;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (inventory.keysCollected >= 1 && !doorUnlocked)
            {
                doorUnlocked = true;
                inventory.keysCollected -= 1;
                OpenDoor();
            }

            if (doorUnlocked)
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = emptySprite;
        fogOfWar.SetActive(false);
        doorCollider.isTrigger = true;
        fogOfWarInside.SetActive(true);
    }

    public void CloseDoor()
    {
        spriteRenderer.sprite = unlockedSprite;
        fogOfWar.SetActive(true);
        doorCollider.isTrigger = false;
        fogOfWarInside.SetActive(false);
    }

}
