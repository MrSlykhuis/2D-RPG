using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;
    public CoffeeBar coffeeBar;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Sound Effects").GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(coffeeBar.currentCoffee > 0)
            {
                audioSource.Play();
                Shoot();
            }
            
        }
    }

   void Shoot()
    {
        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        coffeeBar.CoffeeCounter(-1);
    }
}
