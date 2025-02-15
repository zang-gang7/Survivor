using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Install : MonoBehaviour
{
    public float InstallTime = 0;
    public float ShootCooltime = 0;
    public float Damage = 0;
    public int Count = 0;

    private float currentTime = 0;
    private float shootTime = 0f;

    public GameObject BulletObj;
    public Scanner scanner;
    private void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        shootTime += Time.deltaTime;

        if(ShootCooltime < shootTime && scanner.nearestTarget!=null)
        {
            shootTime = 0;


            Vector3 targetPos = scanner.nearestTarget.position;
            Vector3 dir = targetPos - transform.position;
            dir = dir.normalized;

            var bulletObj = Instantiate(BulletObj, transform.position, Quaternion.identity);
            var bullet = bulletObj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bulletObj.transform.position = transform.position;
                bulletObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

                bullet.Init(Damage, Count, dir);
            }
        }
        if (InstallTime < currentTime)
            Destroy(transform.gameObject);
    }
}
