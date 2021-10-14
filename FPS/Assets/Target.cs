using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;


    //ifall ens liv är under eller lika med 0, så triggas Die()
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    //När Die triggas så förstörs objektet
    void Die()
    {
        Destroy(gameObject);
    }
}
