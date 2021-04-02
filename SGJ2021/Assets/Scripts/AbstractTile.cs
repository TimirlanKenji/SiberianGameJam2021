using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class AbstractTile : MonoBehaviour
{
	[SerializeField] private Sprite[] sprites = null;
	[SerializeField] private float speed = 1.0f;
	
	private SpriteRenderer sr;
	
	private int currentIndex = 0;

	protected bool eventIsActive = true;
	
	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	
	private void Update()
	{
		ChangeSprite();
	}
	
	private void FixedUpdate()
	{
		sr.sprite = sprites[currentIndex];
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
			speed -= 0.02f;
			if(speed <= 0)
			{
				if(currentIndex == sprites.Length - 1)
					currentIndex = 0;
				else
					currentIndex++;
				speed = 1.0f;
			}
		}
	}

	public abstract void BeginTileEvent();
}
