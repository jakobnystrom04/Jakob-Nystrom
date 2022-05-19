using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour

{
    public Rigidbody rb;
    public GameObject Orientation;
    float FirstInputTime = 0;
    float FirstInputTime2 = 0;
    float TimeSinceFirstInput = 1;
    float TimeSinceFirstInput2 = 1;
    float DoubleInputCD = -2;
    float DoubleInputCD2 = -2;
    float DoubleInputWindow = -10;
    float DoubleInputWindow2 = -10;
    float triggerOnce = 0;
    float triggerOnce2 = 0;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceFirstInput = Time.time - FirstInputTime;

        if (Time.time - DoubleInputCD >= 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (TimeSinceFirstInput <= 0.5)
                {
                    DoubleInputCD = Time.time;
                    FirstInputTime = 0;
                    DoubleInputWindow = Time.time;
                }

                else
                {
                    FirstInputTime = Time.time;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (TimeSinceFirstInput2 <= 0.5)
                {
                    DoubleInputCD2 = Time.time;
                    FirstInputTime2 = 0;
                    DoubleInputWindow2 = Time.time;
                }

                else
                {
                    FirstInputTime2 = Time.time;
                }
            }



        }

        if (Time.time - DoubleInputWindow <= 0.2)
        {
            if (triggerOnce == 0)
            {
                TimeSlow();
                DashLeft();
                triggerOnce = 1;
                StartCoroutine("TimeNormal");
            }

        }
        else
        {
            triggerOnce = 0;

        }

        if (Time.time - DoubleInputWindow2 <= 0.2)
        {
            if (triggerOnce2 == 0)
            {
                TimeSlow();
                DashLeft();
                triggerOnce2 = 1;
                StartCoroutine("TimeNormal");
            }

        }
        else
        {
            triggerOnce2 = 0;

        }
    }





    void TimeSlow()
    {
        Time.timeScale = 0.10f;
        Time.fixedDeltaTime = Time.timeScale * .02f;

    }

    void DashLeft()
    {
        rb.AddForce(-Orientation.transform.right * 10, ForceMode.Impulse);
    }

    IEnumerator TimeNormal()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;


    }


}