using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectileScript : MonoBehaviour
{
    public GameObject projectilePrefab;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }



    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
