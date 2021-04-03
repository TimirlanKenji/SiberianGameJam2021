using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonumentTile : AbstractTile
{
    [SerializeField] private MonumentCanvas monumentCanvasPrefab = null;
    [TextArea(15, 20)]
    [SerializeField] private string startText = null;
    [TextArea(15, 20)]
    [SerializeField] private string badText = null;
    [TextArea(15, 20)]
    [SerializeField] private string neutralText = null;
    [TextArea(15, 20)]
    [SerializeField] private string goodText = null;

    private MonumentCanvas monumentCanvas;

    public string StartText { get { return startText; } }

    public override void BeginTileEvent()
    {
        monumentCanvas = Instantiate(monumentCanvasPrefab);
    }

    public void Inspect()
    {
        monumentCanvas.BeginInspectation();
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
        {
            GameManager.Instance.Player.ChangeMentalHealth(3);
            monumentCanvas.StoryText.text = goodText;
        }
        else if (diceValue < 3)
        {
            GameManager.Instance.Player.ChangeMentalHealth(-3);
            monumentCanvas.StoryText.text = badText;
        }
        else
            monumentCanvas.StoryText.text = neutralText;
        monumentCanvas.SetCloseButtonActive();
    }
}
