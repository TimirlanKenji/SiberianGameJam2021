using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	
	[SerializeField] private Player playerPrefab = null; // Корабль игрока
	[SerializeField] private Vector2 startPosition = new Vector2(0.5f, 0.5f); // Стартовая позиция
	
	// Собираемые ресурсы
	[Header("Собираемые ресурсы")]
	[SerializeField] private int fuel = 5; // Топливо. Используется при движении на другую клетку
	[SerializeField] private int repaitKit = 0; // Ремонтный набор. Восстанавливает физическое здоровье
	[SerializeField] private int bomb = 0; // Бомба. Применяется для разрушения преград
	[SerializeField] private int letter = 0; // Письмо. Восстанавливает психическое здоровье
	[SerializeField] private int treasures = 0; // Сокровища. Используется как валюта
	[SerializeField] private int panaceitis = 0; // Главный собираемый ресурс. Нужен для победы в игре
	[Space(5f)]

	[SerializeField] private Canvas gameOverCanvas = null;

	private AbstractTile currentTile;
	private AbstractTile previousTile;
	
	public Player Player { get; set; }
	public AbstractTile CurrentTile { get { return currentTile; } }
	public AbstractTile PreviousTile { get { return previousTile; } }
	
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

    private void Update()
    {
		Debug.Log("Player Health: " + Player.Shield);
		Debug.Log("Player Mental: " + Player.Mental);
    }

    public void SetNewCurrentTile(AbstractTile newCurrentTile)
    {
		previousTile = currentTile;
		currentTile = newCurrentTile;
    }

	public void CheckPlayerShield()
    {
		if (Player.Shield == 0)
		{
			Instantiate(gameOverCanvas);
		}
    }
}
