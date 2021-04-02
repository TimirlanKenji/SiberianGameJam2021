using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	
	[SerializeField] private GameObject playerPrefab = null; // Корабль игрока
	[SerializeField] private Vector2 startPosition = new Vector2(0.5f, 0.5f); // Стартовая позиция
	
	// Параметры корабля
	[Header("Параметры корабля")]
	[SerializeField] private int shield = 10; // Физическое здоровье
	[SerializeField] private int mental = 10; // Психическое здоровье
	[SerializeField] private int passability = 1; // Проходимость. Влияет на количество проходимых клеток на карте
	[SerializeField] private int firepower = 3; // Огневая мощь. + к атаке против врагов
	[SerializeField] private int stealth = 2; // Скрытность. + к способности незаметно пройти клетку с врагом
	[Space(5f)]
	
	// Собираемые ресурсы
	[Header("Собираемые ресурсы")]
	[SerializeField] private int fuel = 5; // Топливо. Используется при движении на другую клетку
	[SerializeField] private int repaitKit = 0; // Ремонтный набор. Восстанавливает физическое здоровье
	[SerializeField] private int bomb = 0; // Бомба. Применяется для разрушения преград
	[SerializeField] private int letter = 0; // Письмо. Восстанавливает психическое здоровье
	[SerializeField] private int treasures = 0; // Сокровища. Используется как валюта
	[SerializeField] private int panaceitis = 0; // Главный собираемый ресурс. Нужен для победы в игре
	
	public GameObject Player { get; set; }
	
	public static GameManager Instance { get { return instance; } }
	
	private void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(this);
		
		Player = Instantiate(playerPrefab, startPosition, new Quaternion(0, 0, 0, 0));
	}
}
