using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterFollow : MonoBehaviour
{
    public MonsterController monsterController;
    public GameObject monsterHealthBar;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            monsterController.FollowPlayer();
            monsterHealthBar.SetActive(true);
        }
    }
}
