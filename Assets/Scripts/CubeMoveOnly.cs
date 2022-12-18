using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveOnly : MonoBehaviour
{
    Camera camera;

    private bool isMove;
    private Vector3 targetPosition;

    public float moveSpeed=50f;

    private void Awake()
    {
        camera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                MoveToTP(hit.point);
            }
        }

        Move();
    }
    private void MoveToTP(Vector3 target)
    {
        targetPosition = target;
        isMove = true;
    }



    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(targetPosition, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
            var Dir = targetPosition - transform.position;
            transform.position += Dir.normalized * Time.deltaTime * moveSpeed;
        }
    }
}
