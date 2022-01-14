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
    public GameObject popupTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        monsterHealth = monsterMaxHealth;
        healthSlider.maxValue = monsterMaxHealth;
        healthSlider.value = monsterHealth;
    }


    public void EnemyDamaged(int amount)
    {
        Debug.Log("Spike Trap test");
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        monsterHealth -= amount;
        healthSlider.value = monsterHealth;
        GameObject prefab = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = amount.ToString();
        if (monsterHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}