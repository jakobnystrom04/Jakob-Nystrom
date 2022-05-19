using UnityEngine;

public class gunScript1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
 
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 300f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        //Om du vänsterklickar så triggas Shoot
        {
            Shoot();
        }

        
    }

    void Shoot()
    {
        //Funktionen ansvarar för funktionen av vapnet, animation spelas, den registrerar vad som blir träffat och gör skada på det
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
