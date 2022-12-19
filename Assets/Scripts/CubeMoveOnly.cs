using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveOnly : MonoBehaviour
{
    Camera camera;

    private bool isMove;
    private bool isRotate;
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
        targetPosition.y = transform.position.y;
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

    private void MovingCube()
    {
        float dist = Vector3.Distance(transform.position, targetPosition);


        //MoveToward
        //position을 직접 이동시키는 기능이 아님
        //position의 벡터를 계산하는 방법
        //목표 지점을 알아야 계산 가능
        //목표까지 균등한 크기로 값을 계산
        Vector3.MoveTowards(new Vector3(0, 0, 1), new Vector3(0, 0, 10), 0.2f);



        //Lerp
        //선형보간
        Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(0, 0, 10), 0);


        //Translate
        //position을 직접 이동시키는 함수
        //목표를 몰라도 작동
        //방향만 지정하면 동작한다
        transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        if(dist>0)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        Vector3 dir = targetPosition - transform.position;

        if(isRotate == false || dir == Vector3.zero)
        {
            return;
        }

        var targetRot = Quaternion.LookRotation(dir); //회전방향을 계산(쿼터니언)
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 20f * Time.deltaTime);

        //Quaternion - Lerp
        //직접 회전이 아니라
        //회전해야 하는 쿼터니언 값을 계산
        //목표 회전치를 알아야 한다

        //Rotate
        //물체를 직접 돌림
        //목표 회전치를 몰라도 된다


        //LookAt
        //물체를 직접 회전
        //Vector값만 입력하면 입력한 Vector로 회전이 적용된다
        transform.LookAt(targetPosition);
    }
}
