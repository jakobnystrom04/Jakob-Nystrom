using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamoBastian : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Bastian();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            UnBastian();
        }
    }

    void Bastian()
    {
        
        transform.position = transform.position + new Vector3(0, -3 / 4, 0);
        transform.localScale = new Vector3(1.2f, 0.75f, 1.2f);
    }

    void UnBastian()
    {
        
        transform.position = transform.position + new Vector3(0, 3 / 4, 0);
        transform.localScale = new Vector3(1.2f, 1.5f, 1.2f);
    }
}
