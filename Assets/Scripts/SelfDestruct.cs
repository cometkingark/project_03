using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    ParticleSystem pt;
    // Start is called before the first frame update
    void Awake()
    {
        pt = GetComponent<ParticleSystem>();
        pt.Play();
        StartCoroutine(DestroySelf());
        Debug.Log("portalHere");
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Destroy");
        Destroy(gameObject);
    }
}
