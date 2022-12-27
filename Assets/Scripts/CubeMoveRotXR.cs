using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CubeMoveRotXR : MonoBehaviour
{


    private Vector3 targetPosition;

    public float moveSpeed = 50f;

    public XRRayInteractor interactor;

    public int HP { get; set; } // 프로퍼티, 점수를 가져올 순 있지만 수정할 순 없다.

    public Canvas canvas;


    private void Awake()
    {

    }


    private void Update()
    {

       // RaycastHit hit;
        //if (interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            //MoveToTP(hit.point);
        }


        //Move();
    }
    private void MoveToTP(Vector3 target)
    {
        targetPosition = target;
        targetPosition.y = transform.position.y;

    }



    private void Move()
    {

        if (Vector3.Distance(targetPosition, transform.position) <= 0.1f)
        {

            return;
        }

        var Dir = targetPosition - transform.position;
        transform.forward = Dir;
        transform.position += Dir.normalized * Time.deltaTime * moveSpeed;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
