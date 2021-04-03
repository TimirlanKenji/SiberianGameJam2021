using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private float speed = 0.5f;

    [Header("���������� �������")]
    [SerializeField] private int shield = 10; // ���������� ��������
    [SerializeField] private int maxSheild = 10; // ������������ ���������� ��������
    [SerializeField] private int mental = 10; // ����������� ��������
    [SerializeField] private int maxMental = 10; // ������������ ����������� ��������

    [Header("��������� �������")]
    [SerializeField] private int passability = 1; // ������������. ������ �� ���������� ���������� ������ �� �����
    [SerializeField] private int firepower = 3; // ������� ����. + � ����� ������ ������
    [SerializeField] private int stealth = 1; // ����������. + � ����������� ��������� ������ ������ � ������

    [Header("���������� �������")]
    [SerializeField] private int fuel = 5; // �������. ������������ ��� �������� �� ������ ������
    [SerializeField] private int repaitKit = 0; // ��������� �����. ��������������� ���������� ��������
    [SerializeField] private int rocket = 0; // ������. ����������� ��� ���������� �������
    [SerializeField] private int letter = 0; // ������. ��������������� ����������� ��������
    [SerializeField] private int treasures = 0; // ���������. ������������ ��� ������
    [SerializeField] private int panaceitis = 0; // ������� ���������� ������. ����� ��� ������ � ����
    [Space(5f)]

    private SpriteRenderer sr;
    private float currentSpeed;
    private int currentIndex;

    public int Shield { get { return shield; } }
    public int MaxSheild { get { return maxSheild; } }
    public int Mental { get { return mental; } }
    public int Stealth { get { return stealth; } }

    public int Firepower { get { return firepower; } }

    public Sprite Sprite { get { return sprites[currentIndex]; } }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        currentSpeed = speed;
    }

    private void Update()
    {
        sr.sprite = sprites[currentIndex];
    }

    private void FixedUpdate()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (sprites.Length > 0)
        {
            currentSpeed -= 0.02f;
            if (currentSpeed <= 0)
            {
                if (currentIndex == sprites.Length - 1)
                    currentIndex = 0;
                else
                    currentIndex++;
                currentSpeed = speed;
            }
        }
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
        GameManager.Instance.CheckPlayerShield();
    }

    public void ChangeMentalHealth(int number)
    {
        mental += number;
        if (mental > maxMental)
            mental = maxMental;
        else if (mental < 0)
            mental = 0;
    }

    public void ChangeRocketNumber(int number)
    {
        rocket += number;
    }

    public void ChangeLetterNumber(int number)
    {
        letter += number;
    }

    public void IncreaseMaxHealth(int number)
    {
        maxSheild += number;
    }
}
