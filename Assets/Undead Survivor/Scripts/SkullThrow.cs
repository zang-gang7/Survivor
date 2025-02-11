using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullThrow : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform throwPoint;
    public float count;
    public float range;
    public float coolTime;

    Player player;

    private void Start()
    {
        player = GameManager.instance.player;
    }

    private void Update()
    {
        if (player == null)
            return;
    }
}  
