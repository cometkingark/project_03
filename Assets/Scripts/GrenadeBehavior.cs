using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sp;

    public GameObject grenadeBody;
    public ExplodeGraphic explodeThis;
    private AudioSource ad;

    public float power = 100f;
    public float explosionRadius = 20f;
    public float upForce = 1f;
    private bool targetHit;


    //[Header("Particles")]
    // public ParticleSystem explodeParticle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sp = GetComponent<SphereCollider>();
        ad = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision);
        if (targetHit)
            return;
        else
            targetHit = true;

        rb.isKinematic = true;

        transform.SetParent(collision.transform);

        Invoke(nameof(Explode), 2f);
    }

    void Explode()
    {



        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody vrb = hit.GetComponent<Rigidbody>();

            if (vrb != null)
            {
                vrb.AddExplosionForce(power, transform.position, explosionRadius, upForce, ForceMode.Impulse);
            }
        }

        //explodeParticle.Play();
        ad.Play();
        explodeThis.ExplodeThis();

        Destroy(grenadeBody);

    }

    

    IEnumerator DestroyWhole()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
