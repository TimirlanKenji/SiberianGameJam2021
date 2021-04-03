using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonumentCanvas : MonoBehaviour
{
    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI diceValueText = null;

    [Header("Кнопки")]
    [SerializeField] private Button inspectButton = null;
    [SerializeField] private Button leaveButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private Button rollTheDiceButton = null;

    private MonumentTile parentTile;

    public TextMeshProUGUI DiceValueText { get { return diceValueText; } }

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        parentTile = GameManager.Instance.CurrentTile.GetComponent<MonumentTile>();
    }

    public void Inspect()
    {
        parentTile.Inspect();
    }

    public void Leave()
    {
        parentTile.Leave();
    }

    public void Close()
    {
        Destroy(gameObject);
    }

    public void RollTheDice()
    {
        parentTile.RollTheDice();
    }

    public void BeginInsceptation()
    {
        inspectButton.gameObject.SetActive(false);
        leaveButton.gameObject.SetActive(false);
        rollTheDiceButton.gameObject.SetActive(true);
    }

    public void SetCloseButtonActive()
    {
        inspectButton.interactable = false;
        leaveButton.interactable = false;
        rollTheDiceButton.interactable = false;
        closeButton.gameObject.SetActive(true);
    }
}
