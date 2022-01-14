using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneLoaded : MonoBehaviour
{
    //Reference to the keyManager so it knows to load keys
    GameObject gameManager;
    KeyManager keyManager;
    CashManager cashManager;
    public GameObject keyPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        //Locate the KeyManager and GameManager components/object
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        keyManager = gameManager.GetComponent<KeyManager>();
        cashManager = gameManager.GetComponent<CashManager>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        keyManager.NewSceneLoaded(sceneName);
        keyManager.KeyDialogueUpdate();
        cashManager.NewSceneLoaded(sceneName);
        cashManager.CashDialogueUpdate(0);
    }
}