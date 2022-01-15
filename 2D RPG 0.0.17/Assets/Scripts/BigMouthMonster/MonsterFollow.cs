using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterFollow : MonoBehaviour
{
    public MonsterController monsterController;
    public GameObject monsterHealthBar;
    public Collider2D escapeRange;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        monsterController = this.GetComponentInParent<MonsterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCollider.IsTouching(escapeRange))
        {

        }
        else
        {
            monsterController.followPlayer = false;
            monsterHealthBar.SetActive(false);
        }
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
