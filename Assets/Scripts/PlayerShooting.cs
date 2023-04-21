using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    [Header("Bullet Status")]
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;

    [Header("Bullet Spawners")]
    [SerializeField] GameObject fireRight;
    [SerializeField] GameObject fireLeft;
    [SerializeField] GameObject fireUp;
    [SerializeField] GameObject fireDown;

    GameObject bulletSpawner;
    PlayerController ctrl;

    bool canShoot = true;

    void Start()
    {
        ctrl = gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        OnClick();
    }

    void SetBulletSpawnerPos()
    {
        if (ctrl.shootHorizontal > 0) bulletSpawner = fireRight;
        if (ctrl.shootHorizontal < 0) bulletSpawner = fireLeft;
        if (ctrl.shootVertical > 0) bulletSpawner = fireUp;
        if (ctrl.shootVertical < 0) bulletSpawner = fireDown;
    }

    void ShootLogic(float x, float y)
    {
        Vector2 bulletSpawnerPos = bulletSpawner.transform.position;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnerPos, bulletSpawner.transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>();
        bullet.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        bullet.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
        (y > 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        //instantiate the projectile
        SetBulletSpawnerPos();
        ShootLogic(ctrl.shootHorizontal, ctrl.shootVertical);
        bulletSpawner = null;

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void ShootFail()
    {
        // add logic to the shooting failing
    }

    void OnClick()
    {
        if (canShoot && ctrl.shootHorizontal != 0 || canShoot && ctrl.shootVertical != 0)
        {
            StartCoroutine(Shoot());
        }
        // else ShootFail();
    }
}
