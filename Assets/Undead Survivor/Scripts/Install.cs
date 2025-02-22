using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Install : MonoBehaviour
{
    public float InstallTime = 0;
    public float ShootCooltime = 0;
    public float Damage = 0;
    public int Count = 0;
    public bool isRoationBullet = false;
    private float currentTime = 0;
    private float shootTime = 0f;

    public GameObject BulletObj;
    public GameObject ObjForRotation;

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

            if(isRoationBullet)
            {
                var bulletObj = Instantiate(BulletObj, transform.position, Quaternion.identity, ObjForRotation.transform);
                bulletObj.transform.localScale *= 0.3f;
                var bullet = bulletObj.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bulletObj.transform.position = transform.position + new Vector3(3,0,0);

                    bullet.Init(Damage, Count, dir);
                }
            }
            else
            {
                var bulletObj = Instantiate(BulletObj, transform.position, Quaternion.identity);
                var bullet = bulletObj.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bulletObj.transform.position = transform.position;
                    bulletObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);

                    bullet.Init(Damage, Count, dir);
                }
            }

        }
        if (InstallTime < currentTime)
            Destroy(transform.gameObject);

        if(ObjForRotation!=null)
            ObjForRotation.transform.Rotate(Vector3.back * 150f * Time.deltaTime);
    }
}
