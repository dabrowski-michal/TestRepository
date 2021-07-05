using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int projectileDamage, movementSpeed;
    protected PlayerGun playerGun;
    protected Rigidbody rigidbody;


    protected void Start()
    {
        if (!playerGun) playerGun = FindObjectOfType<PlayerGun>();
        rigidbody = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        Vector3 origin = new Vector3(0, 0, 0);
        if (Vector3.Distance(transform.position, origin) > 40f)
        {
            transform.position = origin;
            playerGun.DestroyProjectile(gameObject);
        }
    }

    protected void FixedUpdate()
    {
        Vector3 direction = transform.forward;
        rigidbody.MovePosition(rigidbody.position + direction * movementSpeed * Time.fixedDeltaTime);
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DealDamage(other.GetComponent<Enemy>());
            playerGun.DestroyProjectile(gameObject);
        }
    }


    protected virtual void DealDamage(Enemy enemy) { }

}
