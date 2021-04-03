using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinTile : AbstractTile
{
    [SerializeField] private BattleCanvas battleCanvasPrefab = null;
    [SerializeField] private AbstractEnemy enemyData = null;

    private BattleCanvas battleCanvas;
    private EnemyContainer enemy;

    public EnemyContainer Enemy { get { return enemy; } }

    protected override void Awake()
    {
        base.Awake();
        if (enemyData != null)
            enemy = new EnemyContainer(enemyData);
    }

    public override void BeginTileEvent()
    {
        battleCanvas = Instantiate(battleCanvasPrefab);
    }

    public void Attack()
    {
        // Очистить канвас и начать бой
        battleCanvas.BeginFight();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Stealth()
    {
        int diceValue = Random.Range(GameManager.Instance.Player.Stealth, 7);
        battleCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
        {
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
            battleCanvas.SetCloseButtonActive();
        }
        else
        {
            // Очистить канвас и начать бой
            battleCanvas.BeginFight();
            eventIsActive = false;
            GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
            GameManager.Instance.Player.GetDamage(enemy.Damage);
        }
    }

    public void Escape()
    {
        GameManager.Instance.SetNewCurrentTile(GameManager.Instance.PreviousTile);
        battleCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        int diceValue = Random.Range(1, 7);
        battleCanvas.DiceValueText.text = diceValue.ToString();
        if (diceValue > 4)
            enemy.GetDamage(GameManager.Instance.Player.Firepower);
        while (GameManager.Instance.Player.Shield > 0 && enemy.Health > 0)
        {
            GameManager.Instance.Player.GetDamage(enemy.Damage);
            enemy.GetDamage(GameManager.Instance.Player.Firepower);
        }
        battleCanvas.SetCloseButtonActive();
    }
}
