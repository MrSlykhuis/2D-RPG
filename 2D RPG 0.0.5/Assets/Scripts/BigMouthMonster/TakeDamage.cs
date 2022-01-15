using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float attackPower = 1;

    public PlayerController playerController;
    public Rigidbody2D playerRb;
    public float knockbackForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector3 difference = transform.position - collision.transform.position;
            playerRb.transform.Translate(difference * knockbackForce);
            playerController.TakeDamage(1);
        }
    }
}
