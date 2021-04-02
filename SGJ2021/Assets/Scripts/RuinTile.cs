using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinTile : AbstractTile
{
    [SerializeField] private BattleCanvas battleCanvasPrefab = null;
    [SerializeField] private int enemyDamage = 1;

    private BattleCanvas battleCanvas;

    public override void BeginTileEvent()
    {
        battleCanvas = Instantiate(battleCanvasPrefab);
    }

    public void Attack()
    {
        int diceValue = Random.Range(1, 7);
        battleCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        else
        {
            GameManager.Instance.Player.GetDamage(enemyDamage);
            GameManager.Instance.CheckPlayerShield();
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        }
        eventIsActive = false;
        Destroy(battleCanvas.gameObject);
    }

    public void Stealth()
    {
        int diceValue = Random.Range(GameManager.Instance.Player.Stealth, 7);
        battleCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        else
        {
            GameManager.Instance.Player.GetDamage(enemyDamage);
            GameManager.Instance.CheckPlayerShield();
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
        }
        eventIsActive = false;
        Destroy(battleCanvas.gameObject);
    }

    public void Escape()
    {
        GameManager.Instance.SetNewCurrentTile(GameManager.Instance.PreviousTile);
        Destroy(battleCanvas.gameObject);
    }
}
