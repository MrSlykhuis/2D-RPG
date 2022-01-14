using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindCounter : MonoBehaviour
{
    public GameObject character;
    public Rigidbody2D characterRb;
    public int characterSpeed = 1;
    public Animator animator;
    public float waitTime;
    public bool facingRight = true;
    public bool facingUp = true;
    public bool walking = false;

    private void Start()
    {
        waitTime = 2;
        animator.SetBool("Turn Up", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (walking)
        {
            characterRb.transform.Translate(Vector3.right * characterSpeed * Time.deltaTime);

        }
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            NewState();

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flip();

    }

    void NewState()
    {
        waitTime = Random.Range(1, 3);
        if (facingUp)
        {
            Flip();
            animator.SetBool("Walking", true);
            animator.SetBool("Turn Up", false);
            walking = true;
            facingUp = false;
        }
        else
        {
            FaceUp();
            walking = false;
            facingUp = true;
        }
    }

    void Flip()
    {
        if (facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }
    void FaceUp()
    {
        animator.SetBool("Turn Up", true);
        animator.SetBool("Walking", false);
    }

}
