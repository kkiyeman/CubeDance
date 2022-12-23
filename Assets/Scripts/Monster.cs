using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float speed = 2f;
    private float speedFactor = 2f;

    private Transform target;

    private void Start()
    {
        float randSpeefFactor = Random.Range(1 - speedFactor, 1 + speedFactor);
        speed *= randSpeefFactor;
    }

    public void SetTarget(Transform tr)
    {
        target = tr;
    }

    private void Update()
    {
        if (target == null)
            return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector3 lookPos = target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, 2 * Time.deltaTime);
    }
}
