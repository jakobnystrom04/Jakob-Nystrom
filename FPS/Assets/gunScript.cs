using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float damage = 0f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        //Ifall du vänsterklickar och din cooldown har gått ner
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            //Startar cooldown
            Shoot();
            //startar funktionen Shoot
        }

       
    }
    
    void Shoot()
    {
        //Funktionen ansvarar för funktionen av vapnet, animation spelas, den registrerar vad som blir träffat och gör skada på det.
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.name != ("First Person Player"))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null && hit.transform.name != ("Cylinder") && hit.transform.name != ("Cylinder(Clone)"))
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
        }
    }
}
