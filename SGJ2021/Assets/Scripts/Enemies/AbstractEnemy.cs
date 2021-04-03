using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : ScriptableObject
{
    [SerializeField] protected int health = 0;
    [SerializeField] private int damage = 0;
    [SerializeField] private Sprite sprite = null;

    public int Health { get { return health; } }
    public Sprite Sprite { get { return sprite; } }

    public int Damage { get { return damage; } }
}
