using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer
{
    private int health;
    private int damage;
    private Sprite sprite;

    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public Sprite Sprite { get { return sprite; } }
    public EnemyContainer(AbstractEnemy enemyData)
    {
        health = enemyData.Health;
        damage = enemyData.Damage;
        sprite = enemyData.Sprite;
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;
    }
}
