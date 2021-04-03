using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTile : AbstractTile
{
    [SerializeField] TankCanvas tankCanvasPrefab = null;

    private TankCanvas tankCanvas;

    public override void BeginTileEvent()
    {
        tankCanvas = Instantiate(tankCanvasPrefab);
    }

    public void Inspect()
    {
        tankCanvas.BeginInsceptation();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Leave()
    {
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        tankCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        int diceValue = Random.Range(1, 7);
        tankCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
            GameManager.Instance.Player.ChangeRocketNumber(1);
        else if (diceValue == 4)
            GameManager.Instance.Player.ChangeLetterNumber(1);
        else if (diceValue == 3)
            GameManager.Instance.Player.IncreaseMaxHealth(1);
        tankCanvas.SetCloseButtonActive();
    }
}
