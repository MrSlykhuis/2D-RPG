using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int monsterMaxHealth = 3;
    public int monsterHealth;
    public bool followPlayer;
    public Transform playerTransform;
    public float followSpeed = 3;
    public Rigidbody2D enemyRb;

    public float knockbackForce = 1;
    public float knockbackTime;
    public float knockbackTimeTotal = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        monsterHealth = monsterMaxHealth;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This code is set up to follow the player once triggered
        if (followPlayer == true)
        {
            if(knockbackTime <= 0)
            {
                enemyRb.MovePosition(Vector2.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime));
            }
            else
            {
                knockbackTime -= Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            EnemyDamaged(1);
        }
    }
    public void EnemyDamaged(int amount)
    {
        monsterHealth -= (amount);
        if (monsterHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void FollowPlayer()
    {
        followPlayer = true;
    }

}