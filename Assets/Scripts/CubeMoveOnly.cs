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
        //position�� ���� �̵���Ű�� ����� �ƴ�
        //position�� ���͸� ����ϴ� ���
        //��ǥ ������ �˾ƾ� ��� ����
        //��ǥ���� �յ��� ũ��� ���� ���
        Vector3.MoveTowards(new Vector3(0, 0, 1), new Vector3(0, 0, 10), 0.2f);



        //Lerp
        //��������
        Vector3.Lerp(new Vector3(0, 0, 1), new Vector3(0, 0, 10), 0);


        //Translate
        //position�� ���� �̵���Ű�� �Լ�
        //��ǥ�� ���� �۵�
        //���⸸ �����ϸ� �����Ѵ�
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

        var targetRot = Quaternion.LookRotation(dir); //ȸ�������� ���(���ʹϾ�)
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 20f * Time.deltaTime);

        //Quaternion - Lerp
        //���� ȸ���� �ƴ϶�
        //ȸ���ؾ� �ϴ� ���ʹϾ� ���� ���
        //��ǥ ȸ��ġ�� �˾ƾ� �Ѵ�

        //Rotate
        //��ü�� ���� ����
        //��ǥ ȸ��ġ�� ���� �ȴ�


        //LookAt
        //��ü�� ���� ȸ��
        //Vector���� �Է��ϸ� �Է��� Vector�� ȸ���� ����ȴ�
        transform.LookAt(targetPosition);
    }
}
