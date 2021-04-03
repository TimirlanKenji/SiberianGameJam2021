using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineTile : AbstractTile
{
    [SerializeField] SubmarineCanvas submarineCanvasPrefab = null;
    [TextArea(15, 20)]
    [SerializeField] private string startText = null;
    [TextArea(15, 20)]
    [SerializeField] private string nothingText = null;
    [TextArea(15, 20)]
    [SerializeField] private string maxHealthText = null;
    [TextArea(15, 20)]
    [SerializeField] private string letterText = null;
    [TextArea(15, 20)]
    [SerializeField] private string mentalHealthText = null;
    [TextArea(15, 20)]
    [SerializeField] private string rocketText = null;

    private SubmarineCanvas submarineCanvas;

    public string StartText { get { return startText; } }

    public override void BeginTileEvent()
    {
        submarineCanvas = Instantiate(submarineCanvasPrefab);
    }

    public void Inspect()
    {
        submarineCanvas.BeginInspectation();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Leave()
    {
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        submarineCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        int diceValue = Random.Range(1, 7);
        submarineCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue == 6)
        {
            GameManager.Instance.Player.ChangeRocketNumber(1);
            submarineCanvas.StoryText.text = rocketText;
        }
        else if (diceValue == 5)
        {
            GameManager.Instance.Player.ChangeMentalHealth(-1);
            submarineCanvas.StoryText.text = mentalHealthText;
        }
        else if (diceValue == 4)
        {
            GameManager.Instance.Player.ChangeLetterNumber(1);
            submarineCanvas.StoryText.text = letterText;
        }
        else if (diceValue == 3)
        {
            GameManager.Instance.Player.IncreaseMaxHealth(1);
            submarineCanvas.StoryText.text = maxHealthText;
        }
        else
            submarineCanvas.StoryText.text = nothingText;
        submarineCanvas.SetCloseButtonActive();
    }
}
