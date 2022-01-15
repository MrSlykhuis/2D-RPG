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

    // Start is called before the first frame update
    void Start()
    {
        monsterHealth = monsterMaxHealth;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //This code is set up to follow the player once triggered
        if (followPlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, followSpeed * Time.deltaTime);

        }
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