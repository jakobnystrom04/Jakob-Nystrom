using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class targetMove : MonoBehaviour
{
    private GameObject wayPoint;
    private Vector3 wayPointPos;


    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
        //Bestämmer en waypoint
    }

    // Update is called once per frame
    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
        //hittar positionen av waypoint

        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        //flyttar objekt mot din waypoint
    }

    
}
