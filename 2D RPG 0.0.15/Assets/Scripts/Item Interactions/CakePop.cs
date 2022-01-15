using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CakePop : MonoBehaviour
{
    private HealthBar healthBar;
    public int healthToRestore = 3;

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    }

    public void CakePopUsed()
    {
        healthBar.Heal(healthToRestore);
        Destroy(gameObject);
    }
}
