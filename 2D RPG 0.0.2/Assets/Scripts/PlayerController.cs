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





    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {

            playerRb.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            playerDirection = "Up";


        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRb.transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
            playerDirection = "Down";
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRb.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            playerDirection = "Right";
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRb.transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            playerDirection = "Left";
        }
}

public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
