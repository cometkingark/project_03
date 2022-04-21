using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeGraphic : MonoBehaviour
{
    public void ExplodeThis()
    {
        ParticleSystem pt = GetComponent<ParticleSystem>();

        pt.Play();
    }
}
