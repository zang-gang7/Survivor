using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CreateCopyAfterTime : MonoBehaviour
{
    private const float copyTime = 5f;
    private float curTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {
        Destroy(this);
    }
    private void FixedUpdate()
    {
        curTime += Time.deltaTime;

        if(copyTime<curTime)
        {
            Copy();
        }
    }
    private void Copy()
    {
        Vector3 randPos = new Vector3(Random.Range(0, 5), Random.Range(0, 5),0);
        Instantiate(transform.gameObject,transform.position + randPos, Quaternion.identity);
        curTime = 0;
    }
}
