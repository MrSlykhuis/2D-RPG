using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyAndCashDialogue : MonoBehaviour
{
    public TMP_Text keyDialogue;
    public TMP_Text cashDialogue;

    public void KeysCollected(int numberOfKeys)
    {
        keyDialogue.text = "X " + numberOfKeys;
    }

    public void CashCollected(int amountOfCash)
    {
        cashDialogue.text = "= $" + amountOfCash;
    }


}

