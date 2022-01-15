using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogue;
    public TMP_Text characterName;
    public GameObject dialogueManager;
    public int dialogueLine;

    public string characterName1;
    public string textBox1;
    public string characterName2;
    public string textBox2;
    public string characterName3;
    public string textBox3;
    public string characterName4;
    public string textBox4;
    public string characterName5;
    public string textBox5;
    public string characterName6;
    public string textBox6;
    public string characterName7;
    public string textBox7;
    public string characterName8;
    public string textBox8;
    public string characterName9;
    public string textBox9;
    public string characterName10;
    public string textBox10;

    //if set to true, this dialogue will delete itself after running.
    public bool oneTimeDialogue;

    private void Update()
    {



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ContinueDialogue();
        }
    }


    public void ContinueDialogue()
    {
        dialogueLine += 1;

        if (dialogueLine == 1)
        {
            characterName.text = characterName1;
            dialogue.text = textBox1;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }

        if (dialogueLine == 2)
        {
            characterName.text = characterName2;
            dialogue.text = textBox2;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 3)
        {
            characterName.text = characterName3;
            dialogue.text = textBox3;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 4)
        {
            characterName.text = characterName4;
            dialogue.text = textBox4;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 5)
        {
            characterName.text = characterName5;
            dialogue.text = textBox5;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 6)
        {
            characterName.text = characterName6;
            dialogue.text = textBox6;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 7)
        {
            characterName.text = characterName7;
            dialogue.text = textBox7;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 8)
        {
            characterName.text = characterName8;
            dialogue.text = textBox8;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }

        }
        if (dialogueLine == 9)
        {
            characterName.text = characterName9;
            dialogue.text = textBox9;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }


        }
        if (dialogueLine == 10)
        {
            characterName.text = characterName10;
            dialogue.text = textBox10;
            if (dialogue.text != "")
            {
                dialogueManager.SetActive(true);
            }
            else
            {
                EndDialogue();
            }


        }
    }
    public void EndDialogue()
    {
        dialogueManager.SetActive(false);
        if (oneTimeDialogue)
        {
            Destroy(gameObject);
        }
    }
}
