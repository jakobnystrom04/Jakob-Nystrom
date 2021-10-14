using UnityEngine;

public class SniperScript : MonoBehaviour
{
    public float damage = 0f;
    public float range = 100f;
    public float fireRate = 2f;
   

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;
    void Update()
    {
        //Weapon cooldown
        if (Input.GetButtonDown("Fire1") &&  Time.time > nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + fireRate;
        }

        


    }

    //När du skjuter, så skickas en raycast som registrerar objektet det träffar och vart på objektet det träffar, förutom om det är din spelare. Ifall det den träffar har en rigidbody används applyforce för att lägga kraft på den. Den gör skada på vad den än träffar. Den spelar även en impact effect där raycasten träffade.
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.name != ("First Person Player"))
            {
                Debug.Log(hit.transform.name);

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
        }
    }
}
