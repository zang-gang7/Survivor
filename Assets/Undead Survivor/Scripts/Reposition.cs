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
        if (!collision.CompareTag("Area"))
            return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        switch (transform.tag)
        {
            case "Enemy":
                if (coll.enabled)
                {
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
                    transform.Translate(ran + dist * 2);
                }
                break;
        }    
    }
}
