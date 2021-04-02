using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class AbstractTile : MonoBehaviour
{
	[SerializeField] private Sprite[] sprites = null;
	[SerializeField] private float speed = 1.0f;
	[SerializeField] private AbstractEvent tileEvent = null;
	
	private SpriteRenderer sr;
	
	private int currentIndex = 0;
	private bool eventIsActive = true;
	
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
			GameManager.Instance.Player.transform.position = transform.position;
		if (eventIsActive)
			eventIsActive = !tileEvent.Begin();
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
}
