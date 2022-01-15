using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public int playerHealth;
    public int playerMaxHealth = 5;
    public Slider healthSlider;

    public GameObject bloodEffect;
    public GameObject healEffect;
    public GameObject popupTextPrefab;

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
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        playerHealth -= damage;
        healthSlider.value = playerHealth;
        GameObject prefab = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = damage.ToString();
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Heal(int restore)
        {
        Instantiate(healEffect, transform.position, Quaternion.identity);
        playerHealth += restore;
        healthSlider.value = playerHealth;
        GameObject prefab = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = restore.ToString();
        if (playerHealth > playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }
        }
    
}
