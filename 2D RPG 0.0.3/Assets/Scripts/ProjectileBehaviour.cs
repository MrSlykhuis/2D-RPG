using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
            
        }
    }

   void Shoot()
    {
        Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
    }
}
