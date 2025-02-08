using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float moveTime = 10f;
    private float curMoveTime = 0f;
    private Vector3 destPosition = Vector3.zero;
    private void OnEnable()
    {
        GameManager.instance.Exps.Add(this);
        curMoveTime = 0;
    }
    private void OnDisable()
    {
        GameManager.instance.Exps.Remove(this);
    }
    public void setMoveToPosition(Vector3 position)
    {
        destPosition = position;
    }
    private void FixedUpdate()
    {
        if(destPosition != Vector3.zero)
        {
            curMoveTime += Time.fixedDeltaTime;

            float xCurPos = Mathf.Lerp(transform.position.x, destPosition.x, curMoveTime / moveTime);
            float yCurPos = Mathf.Lerp(transform.position.y, destPosition.y, curMoveTime / moveTime);
            float zCurPos = Mathf.Lerp(transform.position.z, destPosition.z, curMoveTime / moveTime);

            transform.position = new Vector3(xCurPos, yCurPos, zCurPos);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.GetExp();
            gameObject.SetActive(false);
        }
    }
}
