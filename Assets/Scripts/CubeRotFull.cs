using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotFull : MonoBehaviour
{
    float mousePosx;
    float mousePosy;
    public float mouseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosx += Input.GetAxis("Mouse X") * mouseSpeed;
            mousePosy += Input.GetAxis("Mouse Y") * mouseSpeed;

            transform.localEulerAngles = new Vector3(mousePosy, -mousePosx, 0);
        }
    }
}
