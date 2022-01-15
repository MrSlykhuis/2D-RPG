using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
  
    public bool followPlayer;
    public Transform playerTransform;
    public float followSpeed = 3;
    public Rigidbody2D enemyRb;

    public float knockbackForce = 1;
    public float knockbackTime;
    public float knockbackTimeTotal = 0.2f;
    private float movementTime;
    public float monsterSpeed = 2;
    public bool facingRight = true;

    //this bool can be checked in Unity, and decides whether the monster patrols horizontally.
    public bool horizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        movementTime = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This code is set up to follow the player once triggered
        if (followPlayer == true)
        {
            if (knockbackTime <= 0)
            {
                enemyRb.MovePosition(Vector2.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime));
            }
            else
            {
                knockbackTime -= Time.deltaTime;
            }
        }
        else
        {
            if (horizontal)
            {
                if (facingRight)
                {
                    enemyRb.transform.Translate(Vector3.right * monsterSpeed * Time.deltaTime);
                }
                if (!facingRight)
                {
                    enemyRb.transform.Translate(Vector3.left * monsterSpeed * Time.deltaTime);
                }
                movementTime -= Time.deltaTime;
                if (movementTime <= 0)
                {
                    ChangeDirection();
                }
            }
            else
            {
                if (facingRight)
                {
                    enemyRb.transform.Translate(Vector3.up * monsterSpeed * Time.deltaTime);
                }
                if (!facingRight)
                {
                    enemyRb.transform.Translate(Vector3.down * monsterSpeed * Time.deltaTime);
                }
                movementTime -= Time.deltaTime;
                if (movementTime <= 0)
                {
                    ChangeDirection();
                }
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 difference = transform.position - collision.transform.position;
            enemyRb.AddForce(difference * knockbackForce, ForceMode2D.Impulse);
            InitiateKnockback();
        }
    }

    public void InitiateKnockback()
    {
        knockbackTime = knockbackTimeTotal;
    }  

    public void FollowPlayer()
    {
        followPlayer = true;
    }

    void ChangeDirection()
    {
        if (facingRight)
        {
            facingRight = false;
            movementTime = 2;
        }
        else
        {
            facingRight = true;
            movementTime = 2;
        }
    }
}