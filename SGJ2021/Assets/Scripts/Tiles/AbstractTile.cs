using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class AbstractTile : MonoBehaviour
{
	[SerializeField] private Sprite[] sprites = null;
	[SerializeField] private float speed = 1.0f;

	private float currentSpeed;
	
	private SpriteRenderer sr;
	
	private int currentIndex = 0;

	protected bool eventIsActive = true;
	
	protected virtual void Awake()
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
	
	private void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if (ClickValidator.Validation(transform.position))
        {
			GameManager.Instance.SetNewCurrentTile(this);
			if (eventIsActive)
				BeginTileEvent();
			else
				GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
		}
	}
	
	private void ChangeSprite()
	{
		if(sprites.Length > 0)
		{
			currentSpeed -= 0.02f;
			if(currentSpeed <= 0)
			{
				if(currentIndex == sprites.Length - 1)
					currentIndex = 0;
				else
					currentIndex++;
				currentSpeed = speed;
			}
		}
	}

	public abstract void BeginTileEvent();
}
