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
    /*Enemy에 이미 속도가 있고, 속도에 맞춰 위치 자동으로 이동 중이라 필요 없음
    private void FixedUpdate()
    {
        transform.position = Vector3.zero * speed * Time.deltaTime;
    }
    */


    //속도가 너무 빨라지면 텔레포트 할거라 맥스 속도 지정해야함
    private void SpeedIncrease()
    {
        if (GetComponent<Enemy>() is Enemy enemyComponenet && enemyComponenet.speed <= maxSpeed)
            enemyComponenet.speed = Mathf.Max(enemyComponenet.speed + speedIncrease, maxSpeed);
    }
}
