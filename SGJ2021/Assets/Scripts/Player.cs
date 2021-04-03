using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite sprite = null;

    [Header("Показатели корабля")]
    [SerializeField] private int shield = 10; // Физическое здоровье
    [SerializeField] private int maxSheild = 10; // Максимальное количество здоровья
    [SerializeField] private int mental = 10; // Психическое здоровье

    [Header("Параметры корабля")]
    [SerializeField] private int passability = 1; // Проходимость. Влияет на количество проходимых клеток на карте
    [SerializeField] private int firepower = 3; // Огневая мощь. + к атаке против врагов
    [SerializeField] private int stealth = 1; // Скрытность. + к способности незаметно пройти клетку с врагом

    private SpriteRenderer sr;

    public int Shield { get { return shield; } }
    public int MaxSheild { get { return maxSheild; } }
    public int Stealth { get { return stealth; } }

    public int Firepower { get { return firepower; } }

    public Sprite Sprite { get { return sprite; } }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
    }

    public void SetNewPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void GetDamage(int damage)
    {
        shield -= damage;
        if (shield < 0)
            shield = 0;
    }
}
