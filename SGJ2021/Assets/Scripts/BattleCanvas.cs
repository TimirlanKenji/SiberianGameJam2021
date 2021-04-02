using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI diceValueText = null; 

    public TextMeshProUGUI DiceValueText { get { return diceValueText; } }

    public void Attack()
    {
        GameManager.Instance.CurrentTile.GetComponent<RuinTile>().Attack();
    }

    public void Stealth()
    {
        GameManager.Instance.CurrentTile.GetComponent<RuinTile>().Stealth();
    }

    public void Escape()
    {
        GameManager.Instance.CurrentTile.GetComponent<RuinTile>().Escape();
    }
}
