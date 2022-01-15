using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    public SpikeTrap spikeTrap;
    public bool spikesArmed;
    public float spikeDelay = .5f;
    public float spikeArmedTime;
    public Animator spikeAnim;

    MonsterController monsterController;
    MonsterHealth monsterHealth;
    Collider2D monsterCollider;

    private void Update()
    {
        spikeArmedTime -= Time.deltaTime;
        if (spikeArmedTime <= 0)
        {
            spikesArmed = false;
            spikeAnim.SetBool("SpikeAttack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!spikesArmed)
            {
                StartCoroutine(SpikeDelay());
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            {
                monsterController = collision.GetComponent<MonsterController>();
                spikeTrap.TransferMonsterController(monsterController);

                monsterHealth = collision.GetComponent<MonsterHealth>();
                spikeTrap.TransferMonsterHealth(monsterHealth);

                monsterCollider = collision.GetComponent<CapsuleCollider2D>();
                spikeTrap.TransferMonsterCollider(monsterCollider);
            }
            if (!spikesArmed)
            {
                StartCoroutine(SpikeDelay());
            }
        }

            IEnumerator SpikeDelay()
            {
                yield return new WaitForSeconds(spikeDelay);
                spikesArmed = true;
                spikeArmedTime = 1;
                spikeTrap.SpikeAttack();
            }


        }
    }
