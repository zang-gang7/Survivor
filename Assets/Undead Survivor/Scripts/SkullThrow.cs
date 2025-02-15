using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullThrow : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform throwPoint;
    public float range = 10;
    public float coolTime = 5;
    public float currentTime = 0f;

    Player player;

    private void OnDisable()
    {
        Destroy(this);
    }
    private void Start()
    {
        player = GameManager.instance.player;
        BulletPrefab = Resources.Load<GameObject>("Bullet 2");
    }
    private void FixedUpdate()
    {
        currentTime += Time.deltaTime; //33
    }
    private void Update()
    {
        if (player == null)
            return;

        float dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2));


        if (dist < range && coolTime < currentTime)
        {
            currentTime = 0;
            var BulletObj = Instantiate(BulletPrefab,transform.position,Quaternion.identity);
            var enemyBulletLogic = BulletObj.GetComponent<EnemyBullet>();
            if (enemyBulletLogic != null)
                enemyBulletLogic.setParameter(player.transform.position);
        }
    }
}  
