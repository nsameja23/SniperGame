using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float bulletLife;

    // Use this for initialization this is my change
    void Start()
    {
        bulletLife = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
