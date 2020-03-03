using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : DragUI
{
    public Tower towerType;

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
