using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositeTile : AbstractTile
{
    public override void BeginTileEvent()
    {
        GameManager.Instance.Player.SetNewPosition(GameManager.Instance.CurrentTile.transform.position);
    }
}
