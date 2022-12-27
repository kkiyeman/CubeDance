using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunRoot;
    public ParticleSystem partGunRoot;
    public Transform bullet;

    public float delay = 0.1f;
    public float damage = 2;

    private bool canShoot = true;

    public void Shoot()
    {
        if (!canShoot)
            return;
        Debug.Log("Shot On!");
        //canShoot = false;

        partGunRoot.transform.position = gunRoot.position;
        partGunRoot.Play();

        var bullette = Instantiate(bullet, gunRoot.position,gunRoot.rotation);
        bullette.gameObject.SetActive(true);
        bullette.transform.localScale = new Vector3(3, 3, 3);
        
        //Invoke("CheckDelay", delay);
    }

    private void CheckDelay()
    {
        canShoot = true;
    }

   
}
