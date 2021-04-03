using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DepositeCanvas : MonoBehaviour
{
    [Header("Текст")]
    [SerializeField] private TextMeshProUGUI storyText = null;

    [Header("Кнопки")]
    [SerializeField] private Button inspectButton = null;
    [SerializeField] private Button closeButton = null;

    private DepositeTile parentTile;

    public TextMeshProUGUI StoryText { get { return storyText; } }

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        parentTile = GameManager.Instance.CurrentTile.GetComponent<DepositeTile>();
        storyText.text = parentTile.StartText;
    }

    public void Inspect()
    {
        inspectButton.gameObject.SetActive(false);
        parentTile.Inspect();
    }

    public void Close()
    {
        Destroy(gameObject);
    }

    public void SetCloseButtonActive()
    {
        inspectButton.interactable = false;
        closeButton.gameObject.SetActive(true);
    }
}
