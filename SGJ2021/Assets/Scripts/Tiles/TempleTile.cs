using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleTile : AbstractTile
{
    [SerializeField] private TempleCanvas templeCanvasPrefab = null;
    [TextArea(15, 20)]
    [SerializeField] private string startText = null;
    [TextArea(15, 20)]
    [SerializeField] private string badText = null;
    [TextArea(15, 20)]
    [SerializeField] private string neutralText = null;
    [TextArea(15, 20)]
    [SerializeField] private string goodText = null;

    private TempleCanvas templeCanvas;

    public string StartText { get { return startText; } }

    public override void BeginTileEvent()
    {
        templeCanvas = Instantiate(templeCanvasPrefab);
    }

    public void Inspect()
    {
        templeCanvas.BeginInspectation();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Leave()
    {
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        templeCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        int diceValue = Random.Range(1, 7);
        templeCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
        {
            GameManager.Instance.Player.IncreaseCurrentHealth(2);
            templeCanvas.StoryText.text = goodText;
        }
        else if (diceValue < 3)
        {
            GameManager.Instance.Player.GetDamage(2);
            templeCanvas.StoryText.text = badText;
        }
        else
            templeCanvas.StoryText.text = neutralText;
        templeCanvas.SetCloseButtonActive();
    }
}
