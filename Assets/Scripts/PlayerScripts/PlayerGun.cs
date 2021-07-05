using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab, fireStrikePrefab, iceBlastPrefab;

    [SerializeField]
    private float fireStrikeCoolDown, iceBlastCoolDown;

    private bool fireStrikeReady = true, iceBlastReady = true;

    [SerializeField]
    private GameObject fireStrikeButton, iceBlastButton;

    [SerializeField]
    private Transform gunOrigin;

    private ObjectPool objectPool;


    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1")) ShootBullet();
        if (Input.GetKeyDown(KeyCode.Alpha1)) CastFireStrike();
        if (Input.GetKeyDown(KeyCode.Alpha2)) CastIceBlast();
    }

    public void ShootBullet()
    {
        ShootProjectile(bulletPrefab);
    }

    public void CastFireStrike()
    {
        if (fireStrikeReady)
        {
            fireStrikeReady = false;
            fireStrikeButton.SetActive(false);
            ShootProjectile(fireStrikePrefab);
            StartCoroutine(FireStrikeCooldown());
        }
    }

    public void CastIceBlast()
    {
        if (iceBlastReady)
        {
            iceBlastReady = false;
            iceBlastButton.SetActive(false);
            ShootProjectile(iceBlastPrefab);
            StartCoroutine(IceBlastCoolDown());
        }
    }

    IEnumerator FireStrikeCooldown()
    {
        yield return new WaitForSeconds(fireStrikeCoolDown);
        fireStrikeReady = true;
        fireStrikeButton.SetActive(true);
    }

    IEnumerator IceBlastCoolDown()
    {
        yield return new WaitForSeconds(iceBlastCoolDown);
        iceBlastReady = true;
        iceBlastButton.SetActive(true);
    }

    public void ShootProjectile(GameObject projectilePrefab)
    {
        GameObject newProjectile = objectPool.GetObjectFromPool(projectilePrefab);

        newProjectile.transform.rotation = gunOrigin.rotation;
        newProjectile.transform.position = gunOrigin.position;
    }

    public void DestroyProjectile(GameObject projectilePrefab)
    {
        objectPool.ReturnObjectBackToPool(projectilePrefab);
    }
}
