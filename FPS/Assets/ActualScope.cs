using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualScope : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Camera.main.fieldOfView = 30;
            //sänker FOV för kameran, alltså zoomar den in.
        }
        else
        {
            Camera.main.fieldOfView = 60;
            //ställer tillbaka FOV för kameran.
        }
    }
}
