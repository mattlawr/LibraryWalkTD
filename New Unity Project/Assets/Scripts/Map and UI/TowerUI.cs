using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : DragUI
{
    public Tower towerType;

    /// <summary>
    /// Pickup tower only if can be afforded by player.
    /// </summary>
    public override void Pickup()
    {
        int currency = GameManager.instance.GetStaff();

        if (currency < towerType.cost)
        {
            return;
        }

        GameManager.instance.AddStaff(-towerType.cost);
        base.Pickup();
    }
}
