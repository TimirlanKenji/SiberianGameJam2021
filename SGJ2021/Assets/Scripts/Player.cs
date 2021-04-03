using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Sprite sprite = null;

    [Header("���������� �������")]
    [SerializeField] private int shield = 10; // ���������� ��������
    [SerializeField] private int maxSheild = 10; // ������������ ���������� ��������
    [SerializeField] private int mental = 10; // ����������� ��������

    [Header("��������� �������")]
    [SerializeField] private int passability = 1; // ������������. ������ �� ���������� ���������� ������ �� �����
    [SerializeField] private int firepower = 3; // ������� ����. + � ����� ������ ������
    [SerializeField] private int stealth = 1; // ����������. + � ����������� ��������� ������ ������ � ������

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
