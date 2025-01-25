using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public TileMapManager tilemapManager_;
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;
        if (collision.tag == "Area")
            tilemapManager_.exitEvent(transform.gameObject);
        //tilemapManager_.exitEvent(transform.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        return;
    }
    private void OnCollisionEnter(Collision collision)
    {
        return;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        return;
        /*
        if (!collision.CompareTag("Area"))
            return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 60);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(13f, 3f), 0f));
                }
                break;
        }    
        */
    }
}
