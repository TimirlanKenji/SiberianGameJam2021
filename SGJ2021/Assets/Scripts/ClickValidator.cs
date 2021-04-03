using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClickValidator
{
	public static bool Validation(Vector2 tilePosition)
	{
		Vector2 playerPosition = GameManager.Instance.Player.transform.position;
		float differenceX = Mathf.Abs(tilePosition.x - playerPosition.x);
		float differenceY = Mathf.Abs(tilePosition.y - playerPosition.y);
		float vectorLength = Mathf.Sqrt(differenceX * differenceX + differenceY * differenceY);
		if (vectorLength == 1)
			return true;
		else
			return false;
	}
}
