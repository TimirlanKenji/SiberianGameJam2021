using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TempleCanvas : MonoBehaviour
{
    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI diceValueText = null;
    [SerializeField] private TextMeshProUGUI storyText = null;

    [Header("Кнопки")]
    [SerializeField] private Button inspectButton = null;
    [SerializeField] private Button leaveButton = null;
    [SerializeField] private Button closeButton = null;
    [SerializeField] private Button rollTheDiceButton = null;

    private TempleTile parentTile;

    public TextMeshProUGUI DiceValueText { get { return diceValueText; } }
    public TextMeshProUGUI StoryText { get { return storyText; } }

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        parentTile = GameManager.Instance.CurrentTile.GetComponent<TempleTile>();
        storyText.text = parentTile.StartText;
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

    public void BeginInspectation()
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
