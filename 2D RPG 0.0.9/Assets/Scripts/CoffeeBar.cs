using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeBar : MonoBehaviour
{
    public int maxCoffee = 5;
    public int currentCoffee;
    public Slider coffeeSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentCoffee = maxCoffee;
        coffeeSlider.maxValue = maxCoffee;
        coffeeSlider.value = currentCoffee;
    }

public void CoffeeCounter(int coffeeChange)
    {
        currentCoffee += coffeeChange;
        coffeeSlider.value = currentCoffee;

        if (currentCoffee < 0)
        {
            currentCoffee = 0;
            coffeeSlider.value = currentCoffee;
        }
        if(currentCoffee > maxCoffee)
        {
            currentCoffee = maxCoffee;
            coffeeSlider.value = currentCoffee;
        }
    }
}
