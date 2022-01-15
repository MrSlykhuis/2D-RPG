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

    //This monster data gets transferred over from SpikeTrigger
    public MonsterController monsterController;
    public MonsterHealth monsterHealth;
    public Collider2D monsterCollider;

    public bool monsterColliderDefined;

    public HealthBar playerHealthBar;
    public SpikeTrigger spikeTrigger;

    public Collider2D playerCollider;
    public Collider2D trapCollider;

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
            if (monsterColliderDefined)
            {
                if (monsterCollider.IsTouching(trapCollider))
                {
                    AttackMonster();
                    monsterColliderDefined = false;
                }
            }
                
           
        }
    }


    //This mess below is the only way I could think of to transfer all of these variables from the SpikeTrigger
    public void TransferMonsterCollider(Collider2D transferredMonsterCollider)
    {
        monsterCollider = transferredMonsterCollider;
        monsterColliderDefined = true;
}
    public void TransferMonsterController(MonsterController transferredMonsterController)
    {
        monsterController = transferredMonsterController;
    }
    public void TransferMonsterHealth(MonsterHealth transferredMonsterHealth)
    {
        monsterHealth = transferredMonsterHealth;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (spikeTrigger.spikesArmed == true)
            {
                AttackPlayer();
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            monsterController = collision.GetComponent<MonsterController>();
            monsterHealth = collision.GetComponent<MonsterHealth>();
            monsterCollider = collision.GetComponent<CapsuleCollider2D>();
            if (spikeTrigger.spikesArmed == true)
            {
                AttackMonster();
            }
        }
    }
    public void SpikeAttack()
    {
        spikeAnim.SetBool("SpikeAttack", true);
    }

    void AttackMonster()
    {

        Debug.Log("Enemy attacked");
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
