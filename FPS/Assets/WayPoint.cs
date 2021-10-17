using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject wayPoint;
    private float timer = 0f;
    private float wayPointTimer = 0.1f;

    // Update is called once per frame
    void Update()
    {
       if (Time.time > timer)
        {
            wayPoint.transform.position = transform.position;
            timer = Time.time + wayPointTimer;
        } 
    }

  
  
}
