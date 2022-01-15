using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    //Key Manager
    public bool villageKey1 = true;
    public bool castleF1Key1 = true;


    public GameObject keyPrefab;


    public void NewSceneLoaded(string sceneName)
    {
        if (sceneName == "Village")
        {
            if (villageKey1 == true)
            {
                Instantiate(keyPrefab, new Vector3(-7, -10, 0), Quaternion.identity);
                villageKey1 = false;
            }
        }

        if (sceneName == "CastleF1")
        {
            if (castleF1Key1 == true)
            {
                Instantiate(keyPrefab, new Vector3(-10, -9.5f, 0), Quaternion.identity);
                castleF1Key1 = false;
            }
        }
    }
}
