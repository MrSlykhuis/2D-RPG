using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public int monsterMaxHealth = 3;
    public int monsterHealth;
    public Slider healthSlider;
    public GameObject bloodEffect;


    // Start is called before the first frame update
    void Start()
    {
        monsterHealth = monsterMaxHealth;
        healthSlider.maxValue = monsterMaxHealth;
        healthSlider.value = monsterHealth;
    }


    public void EnemyDamaged(int amount)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        monsterHealth -= (amount);
        healthSlider.value = monsterHealth;
        if (monsterHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}