using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    public Transform firePoint;

    public GameObject bulletPrefab;


    /*public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShot;
    public float startTimeBtwShot;*/

    void Start()
    {
        
    }

    void Update()
    {
        if (!startCutscene.isCutsceneOn && !Dialog.isDialogOn)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();

            }











            /*Vector3 differnce = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(differnce.y, differnce.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            if (timeBtwShot <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    timeBtwShot = startTimeBtwShot;
                }
            }
            else
            {
                timeBtwShot -= Time.deltaTime;
            }*/


        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
