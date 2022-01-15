using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;
    public CoffeeBar coffeeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(coffeeBar.currentCoffee > 0)
            {
                Shoot();
            }
            
        }
    }

   void Shoot()
    {
        Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
        coffeeBar.CoffeeCounter(-1);
    }
}
