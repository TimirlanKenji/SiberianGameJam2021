using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleCanvas : MonoBehaviour
{
    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI diceValueText = null;

    [Header("Кнопки")]
    [SerializeField] private Button attackButton = null;
    [SerializeField] private Button stelthButton = null;
    [SerializeField] private Button escapeButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private Button rollTheDiceButton = null;

    [Header("Изображения")]
    [SerializeField] private Image playerImage = null;
    [SerializeField] private Image enemyImage = null;
    [SerializeField] private Image playerHealthImage = null;
    [SerializeField] private Image enemyHealthImage = null;

    private float onePercentPlayerHealth;
    private float onePercentEnemyHealth;
    private RuinTile parentTile;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        parentTile = GameManager.Instance.CurrentTile.GetComponent<RuinTile>();
        onePercentPlayerHealth = GameManager.Instance.Player.MaxSheild / 100.0f;
        onePercentEnemyHealth = parentTile.Enemy.Health;
    }

    private void Update()
    {
        if (playerHealthImage.IsActive())
        {
            playerHealthImage.fillAmount = GameManager.Instance.Player.Shield * onePercentPlayerHealth;
            Debug.Log("Player Health: " + GameManager.Instance.Player.Shield);
        }
        if (enemyHealthImage.IsActive())
        {
            enemyHealthImage.fillAmount = parentTile.Enemy.Health * onePercentEnemyHealth;
            Debug.Log("Enemy Health: " + parentTile.Enemy.Health);
        }
    }

    public TextMeshProUGUI DiceValueText { get { return diceValueText; } }

    public void Attack()
    {
        parentTile.Attack();
    }

    public void Stealth()
    {
        parentTile.Stealth();
    }

    public void Escape()
    {
        parentTile.Escape();
    }

    public void Close()
    {
        Destroy(gameObject);
    }

    public void RollTheDice()
    {
        parentTile.RollTheDice();
    }

    public void SetCloseButtonActive()
    {
        attackButton.interactable = false;
        stelthButton.interactable = false;
        escapeButton.interactable = false;
        rollTheDiceButton.interactable = false;
        closeButton.gameObject.SetActive(true);
    }

    public void BeginFight()
    {
        playerImage.sprite = GameManager.Instance.Player.Sprite;
        enemyImage.sprite = parentTile.Enemy.Sprite;
        attackButton.gameObject.SetActive(false);
        stelthButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(false);
        playerImage.gameObject.SetActive(true);
        enemyImage.gameObject.SetActive(true);
        playerHealthImage.gameObject.SetActive(true);
        enemyHealthImage.gameObject.SetActive(true);
        rollTheDiceButton.gameObject.SetActive(true);
    }
}
