using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float dash = 0;
    float dashTime = 1;
    float dashCooldown = -5;
    float dashDuration = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dashTime = Time.time - dash;
        
        if (Time.time - dashCooldown >= 5)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (dashTime <= 0.5)
                {
                    
                    dashCooldown = Time.time;
                    dash = 0;
                    dashDuration = Time.time;
                }   

                else
                {
                    dash = Time.time;
                }
            }
        }

        if(Time.time - dashDuration <= 0.2)
        {
            Debug.Log("lamo get fucked"); 
        }
    }

    
}
