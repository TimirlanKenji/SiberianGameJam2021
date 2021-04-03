using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	
	[SerializeField] private Player playerPrefab = null; // Корабль игрока
	[SerializeField] private Vector2 startPosition = new Vector2(0.5f, 0.5f); // Стартовая позиция
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
