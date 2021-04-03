using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TreasureCanvas : MonoBehaviour
{
    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI diceValueText = null;

    [Header("Кнопки")]
    [SerializeField] private Button attackButton = null;
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
    private TreasureTile parentTile;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        parentTile = GameManager.Instance.CurrentTile.GetComponent<TreasureTile>();
        onePercentPlayerHealth = GameManager.Instance.Player.MaxSheild / 100.0f;
        onePercentEnemyHealth = parentTile.Enemy.Health;
    }

    private void Update()
    {
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
        escapeButton.interactable = false;
        rollTheDiceButton.interactable = false;
        closeButton.gameObject.SetActive(true);
    }

    public void BeginFight()
    {
        playerImage.sprite = GameManager.Instance.Player.Sprite;
        enemyImage.sprite = parentTile.Enemy.Sprite;
        attackButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(false);
        playerImage.gameObject.SetActive(true);
        enemyImage.gameObject.SetActive(true);
        playerHealthImage.gameObject.SetActive(true);
        enemyHealthImage.gameObject.SetActive(true);
        rollTheDiceButton.gameObject.SetActive(true);
    }

    public void ChooseTreasure()
    {
        playerImage.gameObject.SetActive(false);
        enemyImage.gameObject.SetActive(false);
        playerHealthImage.gameObject.SetActive(false);
        enemyHealthImage.gameObject.SetActive(false);
        rollTheDiceButton.gameObject.SetActive(false);
        rollTheDiceButton.gameObject.SetActive(true);
    }
}
