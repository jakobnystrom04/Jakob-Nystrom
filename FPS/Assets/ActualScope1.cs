using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualScope1 : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        //Ifall du högerklickar
        {
            Camera.main.fieldOfView = 15;
            //Kamera zoomar in
        }
        else
        {
            Camera.main.fieldOfView = 60;
            //Kamera zoomar ut
        }
    }
}
