using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalThis : MonoBehaviour
{
    public void Portal()
    {
        ParticleSystem pt = GetComponent<ParticleSystem>();

        pt.Play();
    }
}
