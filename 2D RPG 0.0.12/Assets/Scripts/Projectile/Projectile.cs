using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D projectileRb;
    private float projectileLife = 0.5f;
    public PlayerController playerController;
    public string projectileDirection = "up";


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        projectileDirection = playerController.playerDirection;
    }


    // Update is called once per frame
    void Update()
    {
        projectileLife -= Time.deltaTime;

        if (projectileDirection == "up")
        {
            projectileRb.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (projectileDirection == "right")
        {
            projectileRb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (projectileDirection == "down")
        {
            projectileRb.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (projectileDirection == "left")
        {
            projectileRb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (projectileLife <= 0)
        {
           
            Destroy(gameObject);
        }
    }

       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
