﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeScript : MonoBehaviour
{
    private float LeftMove = 0.67f;
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
            //Om du högerklickar flyttas scope till kameran

        }

        if (Input.GetButtonUp("Fire2"))
        {
            transform.Translate(Vector3.right * LeftMove);
            transform.Translate(Vector3.forward * BackMove);
            //När du släpper högerklick flyttas scopet tillbaka
        }
    }
}
