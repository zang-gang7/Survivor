using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BunnyMoveSpeed : MonoBehaviour
{
    public float speed = 1.5f;
    public float speedIncrease = 1f;
    public float increaseInterval = 3f;


    private void Start()
    {
        InvokeRepeating("SpeedIncrease", increaseInterval, increaseInterval);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.zero * speed * Time.deltaTime;
    }


    private void SpeedIncrease()
    {
        speed += speedIncrease;
    }
}
