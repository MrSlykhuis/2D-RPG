using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{



    public Animator anim;

    public float playerSpeed = 5;
    public Rigidbody2D playerRb;
    public string playerDirection;
    public GameObject launchPoint;
    public Quaternion fromAngle;
    public Quaternion toAngle;

    public float knockbackTimeTotal = 0.2f;
    public float knockbackTime;

    //this freezes movement during cutscenes, scene changes, etc.
    bool frozen;



    // Start is called before the first frame update



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen)
        {
            if (knockbackTime <= 0)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    playerRb.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);

                    //Commands for the Animator
                    anim.SetBool("Down", false);
                    anim.SetBool("Up", true);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Walking Up", true);

                    if (playerDirection != "up")
                    {
                        playerDirection = "up";
                        fromAngle = transform.rotation;
                        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 0f));
                        launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                    }
                }
                else
                {
                    anim.SetBool("Walking Up", false);
                }


                if (Input.GetKey(KeyCode.S))
                {
                    playerRb.transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);

                    //Commands for the Animator
                    anim.SetBool("Down", true);
                    anim.SetBool("Up", false);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", false);
                    anim.SetBool("Walking Down", true);

                    if (playerDirection != "down")
                    {
                        playerDirection = "down";
                        fromAngle = transform.rotation;
                        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 180f));
                        launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                    }

                }
                else
                {
                    anim.SetBool("Walking Down", false);
                }


                if (Input.GetKey(KeyCode.D))
                {
                    playerRb.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);

                    //Commands for the Animator
                    anim.SetBool("Down", false);
                    anim.SetBool("Up", false);
                    anim.SetBool("Right", true);
                    anim.SetBool("Left", false);
                    anim.SetBool("Walking Right", true);
                    if (playerDirection != "right")
                    {
                        playerDirection = "right";
                        fromAngle = transform.rotation;
                        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 270f)); launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                    }
                }
                else
                {
                    anim.SetBool("Walking Right", false);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    playerRb.transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);

                    //Commands for the Animator
                    anim.SetBool("Down", false);
                    anim.SetBool("Up", false);
                    anim.SetBool("Right", false);
                    anim.SetBool("Left", true);
                    anim.SetBool("Walking Left", true);
                    if (playerDirection != "left")
                    {
                        playerDirection = "left";
                        fromAngle = transform.rotation;
                        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 90f));
                        launchPoint.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
                    }
                }
                else
                {
                    anim.SetBool("Walking Left", false);
                }
            }

            else
            {
                knockbackTime -= Time.deltaTime;
            }


        }

    }

    public void FreezePlayer()
    {
        if (frozen)
        {
            frozen = false;
        }
        else
        {
            frozen = true;
        }
    }

    public void InitiateKnockback()
    {
        knockbackTime = knockbackTimeTotal;
    }
   
}
