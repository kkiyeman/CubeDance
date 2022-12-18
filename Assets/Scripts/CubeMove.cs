using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour

{
    Vector3 targetPoint;
    float mousePosx;
    public float mouseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            mousePosx += Input.GetAxis("Mouse X") * mouseSpeed;

            transform.localEulerAngles = new Vector3(0, -mousePosx, 0);
        }

    }

    
}
