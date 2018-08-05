using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public bool hasFired;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    public float shotCounterReset;

    private float shotCounter;

    public Transform firepoint;



    // Use this for initialization
    void Start()
    {
        hasFired = false;
        isFiring = false;
        shotCounterReset = 2.0f;
        shotCounter = shotCounterReset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring && !hasFired)
        {
            //shotCounter = timeBetweenShots;
            BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
            newBullet.speed = bullet.speed = bulletSpeed;
            hasFired = true;
        }
        if (hasFired)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = shotCounterReset;
                isFiring = false;
                hasFired = false;
            }
        }

        //else
        //{
        //    shotCounter = 0;
        //}
    }
}
