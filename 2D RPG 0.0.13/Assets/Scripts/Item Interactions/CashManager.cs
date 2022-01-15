using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CashManager : MonoBehaviour
{
    //Cash Manager
    public bool villageCash1 = true;
    public bool villageCash2 = true;
    public int cashCollected;

    public GameObject cashPrefab;
    private KeyAndCashDialogue keyAndCashDialogue;

    private void Start()
    {
        PlayerPrefs.SetInt("CashCollected", 0);
        keyAndCashDialogue = GameObject.FindGameObjectWithTag("Key Dialogue").GetComponent<KeyAndCashDialogue>();
        cashCollected = PlayerPrefs.GetInt("CashCollected", 0);
    }


    private void Awake()
    {
        cashCollected = PlayerPrefs.GetInt("CashCollected");
    }

    public void CashDialogueUpdate(int value)
    {
        cashCollected += value;
        PlayerPrefs.SetInt("CashCollected", cashCollected);
        keyAndCashDialogue.CashCollected(cashCollected);
    }

    //this function spawns keys in scenes as long as they have not already been spawned
    public void NewSceneLoaded(string sceneName)
    {
        if (sceneName == "Village")
        {
            if (villageCash1 == true)
            {
                Instantiate(cashPrefab, new Vector3(-10, -10, 0), Quaternion.identity);
                villageCash1 = false;
            }

            if (villageCash2 == true)
            {
                Instantiate(cashPrefab, new Vector3(-10, -12, 0), Quaternion.identity);
                villageCash2 = false;
            }
        }

        if (sceneName == "CastleF1")
        {

        }
    }
}
