using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public bool doorOpen;
    public SpriteRenderer spriteRenderer;
    public Sprite closedSprite;
    public Sprite openSprite;
    public GameObject fogOfWar;
    public Collider2D doorCollider;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = openSprite;
        doorCollider.isTrigger = true;
        doorOpen = true;
        fogOfWar.gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        spriteRenderer.sprite = closedSprite;
        doorCollider.isTrigger = false;
        doorOpen = false;
        fogOfWar.gameObject.SetActive(true);
    }
}
