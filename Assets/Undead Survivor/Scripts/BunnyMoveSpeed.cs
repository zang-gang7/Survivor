using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BunnyMoveSpeed : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float speed = 1.5f;
    public float speedIncrease = 1f;
    public float increaseInterval = 3f;

    private void OnDisable()
    {
        Destroy(this);
    }
    private void Start()
    {
        InvokeRepeating("SpeedIncrease", increaseInterval, increaseInterval);
    }

    //
    /*Enemy�� �̹� �ӵ��� �ְ�, �ӵ��� ���� ��ġ �ڵ����� �̵� ���̶� �ʿ� ����
    private void FixedUpdate()
    {
        transform.position = Vector3.zero * speed * Time.deltaTime;
    }
    */


    //�ӵ��� �ʹ� �������� �ڷ���Ʈ �ҰŶ� �ƽ� �ӵ� �����ؾ���
    private void SpeedIncrease()
    {
        if (GetComponent<Enemy>() is Enemy enemyComponenet && enemyComponenet.speed <= maxSpeed)
            enemyComponenet.speed = Mathf.Max(enemyComponenet.speed + speedIncrease, maxSpeed);
    }
}
