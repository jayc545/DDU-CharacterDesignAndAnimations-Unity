using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAir : MonoBehaviour
{
    public float damage = 10f;
    public float range = 1f;
    public float impactForce = 30f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            interaction();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 10))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

        }

    }

    void interaction()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 50))
        {
            Debug.Log(hit.transform.name);

             door der = hit.transform.GetComponent<door>();
            if (der != null)
            {
                der.OpenDoor();
            }
        }
    }
}
