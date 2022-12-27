using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : AttackBase
{
    public float duration = 1f;

    private void OnEnable()
    {
        Invoke("DestroySelf", duration);
    }

    void DestroySelf()
    {
        gameObject.SetActive(false);
    }


}
