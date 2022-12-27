using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackBase
{
    public float speed = 100f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    public void Shoot()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
