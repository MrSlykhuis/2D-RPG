using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueManager;
    public Dialogue dialogue;


    // Start is called before the first frame update
    void Start()
    {
        dialogue = dialogueManager.GetComponent<Dialogue>();
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(dialogue.isTalking == false)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogue.dialogueLine = 1;

            }

        }
    }
}
