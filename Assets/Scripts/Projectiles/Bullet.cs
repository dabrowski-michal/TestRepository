using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(projectileDamage);
    }
}
