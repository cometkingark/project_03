using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBox : MonoBehaviour
{

    private float seed;

    private void Awake()
    {
        seed = UnityEngine.Random.Range(2, 4);   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.up * Mathf.Cos(Time.time * seed) * .1f;
        //gameObject.transform.rotation = Quaternion.Euler(0, Time.time * -70, 0);
        transform.rotation = Quaternion.Euler(0, 2, 0);
        transform.rotation = Quaternion.Euler(Time.time * 200, 0, Time.time * 200);
    }
}
