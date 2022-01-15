using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public CoffeeBar coffeeBar;


    // Start is called before the first frame update
    void Start()
    {
        coffeeBar = GameObject.FindGameObjectWithTag("Player").GetComponent<CoffeeBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrinkCoffee()
    {

            coffeeBar.CoffeeCounter(1);

            Destroy(gameObject);
    }
   
}
