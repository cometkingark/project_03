using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject grenade;
    public GameObject portalPoint;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Particles")]
    public PortalThis portal;
    //public ParticleSystem portalEnter;
    //public ParticleSystem portalExit;


    bool readyToThrow;

    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
        totalThrows = 3;
        throwCooldown = .4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(grenade, attackPoint.position, cam.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        rb.AddForce(forceToAdd, ForceMode.Impulse);


        //Invoke(nameof(Teleport), .1f);
        StartCoroutine(Teleport(hit, projectile, forceDirection));

        //Debug.Log(hit.point);

        // totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);

    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    IEnumerator Teleport(RaycastHit hit, GameObject projectile, Vector3 forceDirection)
    {

        //ParticleSystem prt = projectile.GetComponent<ParticleSystem>();

        //Debug.Log(prt);

        //portal.Portal();

        yield return new WaitForSeconds(.3f);
        if (hit.transform != null)
        {
            Instantiate(portalPoint, projectile.transform.position, projectile.transform.rotation);
            projectile.transform.position = (hit.point - forceDirection * 4); 
            Instantiate(portalPoint, projectile.transform.position, projectile.transform.rotation);
            //portal.Portal();
        } else
        {
            Instantiate(portalPoint, projectile.transform.position, projectile.transform.rotation);
            projectile.transform.position = (projectile.transform.position +  projectile.transform.forward * 1000);
            Instantiate(portalPoint, projectile.transform.position, projectile.transform.rotation);
        }

    }
}
