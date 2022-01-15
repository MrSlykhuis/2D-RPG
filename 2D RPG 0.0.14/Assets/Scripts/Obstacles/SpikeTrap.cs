using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int spikeDamage = 2;
    public float spikeDelay = .5f;
    public float spikeTime = 1;

    public PlayerController playerController;
    private Rigidbody2D playerRb;

    public MonsterController monsterController;
    private MonsterHealth monsterHealth;
    public HealthBar playerHealthBar;
    public SpikeTrigger spikeTrigger;

    public Collider2D playerCollider;
    public Collider2D trapCollider;
    public Collider2D monsterCollider;

    public float knockbackForce = 1;
    public string playerDirection;

    public Animator spikeAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerHealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
        monsterController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterController>();
        monsterCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>();
        monsterHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MonsterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spikeTrigger.spikesArmed == true)
        {
            if (playerCollider.IsTouching(trapCollider))
            {
                AttackPlayer();
            }
            if (monsterCollider.IsTouching(trapCollider))
            {
                AttackMonster();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (spikeTrigger.spikesArmed == true)
            {
                playerController.InitiateKnockback();
                playerHealthBar.TakeDamage(spikeDamage);
            }
        }
  
    }

    public void SpikeAttack()
    {
        spikeAnim.SetBool("SpikeAttack", true);
    }

    void AttackMonster()
    {
        monsterController.InitiateKnockback();
        monsterHealth.EnemyDamaged(spikeDamage);
        spikeTrigger.spikesArmed = false;
    }
    void AttackPlayer()
    {
        playerDirection = playerController.playerDirection;
  
        if(playerDirection == "left")
        {
            playerRb.AddForce(Vector3.right * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (playerDirection == "right")
        {
            playerRb.AddForce(Vector3.left * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (playerDirection == "up")
        {
            playerRb.AddForce(Vector3.down * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (playerDirection == "down")
        {
            playerRb.AddForce(Vector3.up * knockbackForce * Time.deltaTime, ForceMode2D.Impulse);
        }
        playerController.InitiateKnockback();
        playerHealthBar.TakeDamage(spikeDamage);
        spikeTrigger.spikesArmed = false;
    }
}
