using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentTile : AbstractTile
{
    [SerializeField] MonumentCanvas monumentCanvasPrefab = null;

    private MonumentCanvas monumentCanvas;

    public override void BeginTileEvent()
    {
        monumentCanvas = Instantiate(monumentCanvasPrefab);
    }

    public void Inspect()
    {
        monumentCanvas.BeginInsceptation();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Leave()
    {
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        monumentCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        int diceValue = Random.Range(1, 7);
        monumentCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
            GameManager.Instance.Player.ChangeMentalHealth(3);
        else if (diceValue < 3)
            GameManager.Instance.Player.ChangeMentalHealth(-3);
        monumentCanvas.SetCloseButtonActive();
    }
}
