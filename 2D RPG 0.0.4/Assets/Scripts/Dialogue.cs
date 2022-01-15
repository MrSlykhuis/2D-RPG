using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogue;
    public GameObject dialogueManager;
    public int dialogueLine;

    private void Update()
    {



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ContinueDialogue();
        }
    }

    public void ContinueDialogue()
    {
        dialogueLine += 1;

        if(dialogueLine == 1)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "It's dangerous to go alone.";
        }
    
        if(dialogueLine == 2)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "HERO: I know, but I am super awesome, and my middle name is danger.";
        }

        if (dialogueLine == 3)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "Oh, well in that case, have at it.";
        }

        
        if(dialogueLine == 4)
        {
            dialogueManager.SetActive(false);
            dialogueLine = 0;
        }

    }

    public void EndDialogue()
    {
        dialogueManager.SetActive(false);
    }
}
