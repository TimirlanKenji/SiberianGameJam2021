using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTile : AbstractTile
{
    [SerializeField] TankCanvas TankCanvasPrefab = null;
    [TextArea(15, 20)]
    [SerializeField] private string startText = null;
    [TextArea(15, 20)]
    [SerializeField] private string badText = null;
    [TextArea(15, 20)]
    [SerializeField] private string neutralText = null;
    [TextArea(15, 20)]
    [SerializeField] private string goodText = null;

    private TankCanvas tankCanvas;

    public string StartText { get { return startText; } }
    public override void BeginTileEvent()
    {
        tankCanvas = Instantiate(TankCanvasPrefab);
    }

    public void Inspect()
    {
        tankCanvas.BeginInspectation();
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
        if (diceValue == 6)
        {
            GameManager.Instance.Player.ChangeFuelNumber(5);
            tankCanvas.StoryText.text = goodText;

        }
        else if (diceValue > 2)
        {
            GameManager.Instance.Player.ChangeFuelNumber(3);
            tankCanvas.StoryText.text = neutralText;
        }
        else
            tankCanvas.StoryText.text = badText;
        tankCanvas.SetCloseButtonActive();
    }
}
