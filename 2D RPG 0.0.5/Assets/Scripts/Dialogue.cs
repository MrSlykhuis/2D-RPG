using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogue;
    public GameObject dialogueManager;
    private int dialogueLine;
 

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

        //You can add or take away lines of dialogue here. Just type your own words into
        //the "" and remember to make sure the "dialogueLine" numbers match.
        if(dialogueLine == 1)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "It's dangerous to go alone.";
        }

        if (dialogueLine == 2)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "HERO: I know, but I am super awesome, and I love danger.";
        }

        if (dialogueLine == 3)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "But you are a super wimp and you have no weapon.";
        }
        if (dialogueLine == 4)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "But you are a super wimp and you have no weapon.";
        }
        if (dialogueLine == 5)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "But you are a super wimp and you have no weapon.";
        }
        if (dialogueLine == 6)
        {
            dialogueManager.SetActive(true);
            dialogue.text = "But you are a super wimp and you have no weapon.";
        }


        //This line of code will end the conversation. Just make sure that the "dialogueLine"
        //number is correct.
        if (dialogueLine == 7)
        {
            dialogueLine = 0;
            dialogueManager.SetActive(false);
        }
    }

    public void EndDialogue()
    {
        dialogueManager.SetActive(false);
    }
}
