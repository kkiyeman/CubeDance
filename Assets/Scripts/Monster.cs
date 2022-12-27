using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float speed = 1f;
    private float speedFactor = 2f;

    private Transform target;

    private void Start()
    {
        float randSpeefFactor = Random.Range(3 - speedFactor, 1 + speedFactor);
        speed *= randSpeefFactor;
    }


    public void LateSetTarget()
    {
        Invoke("SetTarget", 5);
    }
    public void SetTarget()
    {
        var player = FindObjectOfType<CubeMoveRotXR>();
        target = player.transform;
    }

    private void Update()
    {
        if (target == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 lookPos = target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, 4 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AttackBase>())
        {
            Debug.Log("Direct Hit!!");
            transform.position = GetGeneratePosition();     
        }
    }

    private Vector3 GetGeneratePosition()
    {
        Vector3 ranPos = Vector3.zero;

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            int randX = Random.Range(0, 2);

            float posX = randX == 0 ? 49 : -49;
            float posZ = Random.Range(-49, 49);
            ranPos = new Vector3(posX, 0, posZ);
        }
        else
        {
            int randZ = Random.Range(0, 2);

            float posZ = randZ == 0 ? 49 : -49;
            float posX = Random.Range(-49, 49);
            ranPos = new Vector3(posX, 0, posZ);
        }

        return ranPos;
    }
}
