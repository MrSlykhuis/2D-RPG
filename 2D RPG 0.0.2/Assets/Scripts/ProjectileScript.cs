using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed = 2;
    public string playerDirection;
    public float projectileLife = 1.5f;
    public ParticleSystem projectileBurst;

    private void Start()
    {
        playerDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerDirection;
    }

    // Update is called once per frame
    void Update()
    {
        projectileLife -= Time.deltaTime;
        if(projectileLife <= 0)
        {
            Destroy(gameObject);
        }


        if(playerDirection == "Up")
        {
            projectileRb.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (playerDirection == "Down")
        {
            projectileRb.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (playerDirection == "Right")
        {
            projectileRb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (playerDirection == "Left")
        {
            projectileRb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(projectileBurst, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Wall")
        {
            Instantiate(projectileBurst, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }



}
