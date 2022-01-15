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

    private void Update()
    {
        spikeArmedTime -= Time.deltaTime;
        if(spikeArmedTime <= 0)
        {
            spikesArmed = false;
            spikeAnim.SetBool("SpikeAttack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!spikesArmed)
        {
            StartCoroutine(SpikeDelay());

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
