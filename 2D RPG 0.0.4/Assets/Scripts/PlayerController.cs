using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerHealth;
    public int playerMaxHealth = 5;


    public float playerSpeed = 5;
    public Rigidbody2D playerRb;
    public string playerDirection;
    public GameObject launchPoint;
    public Quaternion fromAngle;
    public Quaternion toAngle;

    public float knockbackTimeTotal = 0.2f;
    public float knockbackTime;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(knockbackTime <= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
                if (playerDirection != "up")
                {
                    playerDirection = "up";
                    fromAngle = transform.rotation;
                    toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0f));
                    launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                }

            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRb.transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
                if (playerDirection != "down")
                {
                    playerDirection = "down";
                    fromAngle = transform.rotation;
                    toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 180f));
                    launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerRb.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
                if (playerDirection != "right")
                {
                    playerDirection = "right";
                    fromAngle = transform.rotation;
                    toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 270f)); launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerRb.transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
                if (playerDirection != "left")
                {
                    playerDirection = "left";
                    fromAngle = transform.rotation;
                    toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 90f));
                    launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                }
            }
        }

        else
        {
            knockbackTime -= Time.deltaTime;
        }
       

    }

public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        knockbackTime = knockbackTimeTotal;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
