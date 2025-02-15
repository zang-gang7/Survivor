using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float MaxmoveTime = 5;
    public float curMoveTime = 0;
    public float bulletSpeed = 1f;
    public float damage = 3f;
    public float ratio = 1f; // ±â¿ï±â
    public float additional = 0;
    Rigidbody2D rigid;
    public Vector3 targetPos,startPos;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void setParameter(Vector3 targetPos_)
    {
        curMoveTime = 0;
        ratio = (transform.position.y - targetPos_.y) / (transform.position.x - targetPos_.x);
        additional = targetPos_.y - ratio * targetPos_.x;
        startPos = transform.position;
        targetPos = targetPos_;
        //y = ax + b
        //b= y - ax
    }
    private void FixedUpdate()
    {
        curMoveTime += Time.deltaTime;
        float x = bulletSpeed * Time.deltaTime;
        if(startPos.x<targetPos.x)
            transform.position += new Vector3(x, 0, 0);
        else
            transform.position += new Vector3(-x, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.x * ratio + additional, transform.position.z);

        if (MaxmoveTime < curMoveTime)
            Destroy(transform.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        else
            GameManager.instance.health -= damage;
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        
        gameObject.SetActive(false);
    }
}
