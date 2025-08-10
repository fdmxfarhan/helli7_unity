using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Bullet Variables:")]
    public float bulletSpeed = 50f;
    public float fireRrate = 0.1f;
    public float bulletDamage = 20f;
    public bool isAuto = false;

    [Header("Initial Setup:")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    float timer = 1;
    void Start()
    {
        
    }
    void Update()
    {
        if(timer > 0) timer -= Time.deltaTime / fireRrate;

        if(isAuto){
            if(Input.GetButton("Fire1") && timer <= 0){
                Shoot();
            }
        }
        else{
            if(Input.GetButtonDown("Fire1") && timer <= 0){
                Shoot();
            }
        }
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward* bulletSpeed, ForceMode.Impulse);
        timer = 1;
    }
}
