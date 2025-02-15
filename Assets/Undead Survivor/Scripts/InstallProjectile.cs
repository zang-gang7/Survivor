using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallProjectile : MonoBehaviour
{
    public float MaxmoveTime = 2;
    public float installRange = 15;
    private float curMoveTime = 0;
    public float bulletSpeed = 1f;
    private float ratio = 1f; // ±â¿ï±â
    private float additional = 0;
    Rigidbody2D rigid;
    private Vector3 targetPos, startPos;
    public GameObject InstallObj;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void setParameter()
    {
        targetPos = transform.position + new Vector3(Random.Range(0, installRange), Random.Range(0, installRange), 0);
        curMoveTime = 0;
        ratio = (transform.position.y - targetPos.y) / (transform.position.x - targetPos.x);
        additional = targetPos.y - ratio * targetPos.x;
        startPos = transform.position;

        //y = ax + b
        //b= y - ax
    }
    private void FixedUpdate()
    {
        curMoveTime += Time.deltaTime;
        float x = bulletSpeed * Time.deltaTime;
        if (startPos.x < targetPos.x)
            transform.position += new Vector3(x, 0, 0);
        else
            transform.position += new Vector3(-x, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.x * ratio + additional, transform.position.z);

        if (MaxmoveTime < curMoveTime)
        {
            transform.gameObject.SetActive(false);
            Instantiate(InstallObj, transform.position, Quaternion.identity);
        }
    }
}
