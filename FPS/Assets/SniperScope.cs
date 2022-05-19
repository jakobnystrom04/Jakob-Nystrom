using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour
{
    private float LeftMove = 0.5f;
    private float BackMove = 0.47f;
    private float upMove = 0.108f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            transform.Translate(Vector3.back * LeftMove);
            transform.Translate(Vector3.right * BackMove);
            transform.Translate(Vector3.up * upMove);
            //När du högerklickar flyttas scopet till kameran
        }

        if (Input.GetButtonUp("Fire2"))
        {
            transform.Translate(Vector3.forward * LeftMove);
            transform.Translate(Vector3.left * BackMove);
            transform.Translate(Vector3.down * upMove);
            //När du släpper högerklick flyttas scopet tillbaka
        }
    }
}
