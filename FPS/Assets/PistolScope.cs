using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScope : MonoBehaviour
{
    private float LeftMove = 0.658f;
    private float BackMove = 0.14f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            transform.Translate(Vector3.left * LeftMove);
            transform.Translate(Vector3.back * BackMove);

        }

        if (Input.GetButtonUp("Fire2"))
        {
            transform.Translate(Vector3.right * LeftMove);
            transform.Translate(Vector3.forward * BackMove);
        }
    }
}
