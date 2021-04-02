using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "TileEvents/BattleEvent")]
public class BattleEvent : AbstractEvent
{
    [SerializeField] private Canvas battleCanvas = null;
    public override bool Begin()
    {
        Instantiate(battleCanvas);
        return true;
    }
}
