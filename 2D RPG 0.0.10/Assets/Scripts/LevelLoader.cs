using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneToLoad;
    public Animator transition;
    public Animator playerAnim;
    GameObject player;
    PlayerController playerController;

    //this checks which direction you want to face
    public bool faceRight;

    public Vector3 targetLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadScene(sceneToLoad));
        }
    }

    IEnumerator LoadScene(string sceneToLoad)
    {
        playerController.FreezePlayer();
        transition.SetTrigger("Start");
     
        if (faceRight)
        {
            playerAnim.SetBool("Walking Right", false);
            playerAnim.SetBool("Walking Left", false);
            playerAnim.SetBool("Walking Up", false);
            playerAnim.SetBool("Walking Down", false);
        }
        if (!faceRight)
        {
            playerAnim.SetBool("Walking Right", false);
            playerAnim.SetBool("Walking Left", false);
            playerAnim.SetBool("Walking Up", false);
            playerAnim.SetBool("Walking Down", false); 
        }
        yield return new WaitForSeconds(1);
        if (faceRight)
        {
            playerAnim.SetBool("Down", false);
            playerAnim.SetBool("Up", false);
            playerAnim.SetBool("Right", true);
            playerAnim.SetBool("Left", false);
        }
        if (!faceRight)
        {
            playerAnim.SetBool("Down", false);
            playerAnim.SetBool("Up", false);
            playerAnim.SetBool("Right", false);
            playerAnim.SetBool("Left", true);
        }

        player.transform.position = targetLocation;
        playerController.FreezePlayer();
        SceneManager.LoadScene(sceneToLoad);
    }

}
