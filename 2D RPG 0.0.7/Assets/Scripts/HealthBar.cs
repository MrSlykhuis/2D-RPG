using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public int playerHealth;
    public int playerMaxHealth = 5;
    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
        healthSlider.maxValue = playerMaxHealth;
        healthSlider.value = playerHealth;
    }




    //Update slider health when taking damage
    public void SetHealth(int playerHealth)
    {
        healthSlider.value = playerHealth;
    }

    //Update actual player health when taking damage
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        healthSlider.value = playerHealth;
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
