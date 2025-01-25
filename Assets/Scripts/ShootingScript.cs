using System.Collections;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("BulletInspec")]
    public GameObject BulletObj;
    public Rigidbody rb;
    public Transform firePoint;

    [Header("BulletStat")]
    public float bulletCooldown;
    public float bulletSpeed;

    [Header("ShakeOption")]
    public ScreenShaker screenShaker;
    public float shakeDuration;

    bool canShoot = true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
            StartCoroutine(ShootingCooldown());
            screenShaker.ShakeIt();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletObj, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
            canShoot = false;
            StartCoroutine(deleteBullet(bullet));
        }
    }

    IEnumerator ShootingCooldown()
    {
        yield return new WaitForSeconds(bulletCooldown);
        canShoot = true;
    }

    IEnumerator deleteBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(1f);
        Destroy(bullet);
    }
}
