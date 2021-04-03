using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositeTile : AbstractTile
{
    [SerializeField] private DepositeCanvas depositeCanvasPrefab = null;
    [TextArea(15, 20)]
    [SerializeField] private string startText = null;
    [TextArea(15, 20)]
    [SerializeField] private string firstText = null;
    [TextArea(15, 20)]
    [SerializeField] private string secondText = null;
    [TextArea(15, 20)]
    [SerializeField] private string thirdText = null;

    private DepositeCanvas depositeCanvas;

    public string StartText { get { return startText; } }

    public override void BeginTileEvent()
    {
        depositeCanvas = Instantiate(depositeCanvasPrefab);
    }

    public void Inspect()
    {
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        if (GameManager.Instance.DepositeCounter == 0)
            depositeCanvas.StoryText.text = firstText;
        else if (GameManager.Instance.DepositeCounter == 1)
            depositeCanvas.StoryText.text = secondText;
        else
            depositeCanvas.StoryText.text = thirdText;
        GameManager.Instance.IncreaseDepositeCounter();
        depositeCanvas.SetCloseButtonActive();
    }
}
