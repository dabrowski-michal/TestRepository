using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlast : Projectile
{
    protected override void DealDamage(Enemy enemy)
    {
        enemy.TakeDamage(projectileDamage);
        enemy.SlowDownEnemy(5);
    }
}
