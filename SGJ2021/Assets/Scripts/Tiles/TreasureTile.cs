using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTile : AbstractTile
{
    [SerializeField] private TreasureCanvas treasureCanvasPrefab = null;
    [SerializeField] private AbstractEnemy enemyData = null;

    private TreasureCanvas treasureCanvas;
    private EnemyContainer enemy;
    private bool enemyIsDefeated = false;

    public EnemyContainer Enemy { get { return enemy; } }

    protected override void Awake()
    {
        base.Awake();
        if (enemyData != null)
            enemy = new EnemyContainer(enemyData);
    }

    public override void BeginTileEvent()
    {
        treasureCanvas = Instantiate(treasureCanvasPrefab);
    }

    public void Attack()
    {
        // Очистить канвас и начать бой
        treasureCanvas.BeginFight();
        eventIsActive = false;
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }

    public void Escape()
    {
        GameManager.Instance.SetNewCurrentTile(GameManager.Instance.PreviousTile);
        treasureCanvas.SetCloseButtonActive();
    }

    public void RollTheDice()
    {
        if (!enemyIsDefeated)
        {
            int diceValue = Random.Range(1, 7);
            treasureCanvas.DiceValueText.text = diceValue.ToString();
            if (diceValue > 4)
                enemy.GetDamage(GameManager.Instance.Player.Firepower);
            while (GameManager.Instance.Player.Shield > 0 && enemy.Health > 0)
            {
                GameManager.Instance.Player.GetDamage(enemy.Damage);
                enemy.GetDamage(GameManager.Instance.Player.Firepower);
            }
            enemyIsDefeated = true;
            treasureCanvas.ChooseTreasure();
        }
        else
        {
            int diceValue = Random.Range(1, 7);
            treasureCanvas.DiceValueText.text = diceValue.ToString();
            if (diceValue > 4)
                GameManager.Instance.Player.IncreaseFirepower(1);
            else if (diceValue > 2)
                GameManager.Instance.Player.IncreaseStealth(1);
            else
                GameManager.Instance.Player.IncreaseMaxHealth(1);
            treasureCanvas.SetCloseButtonActive();
        }
    }
}
