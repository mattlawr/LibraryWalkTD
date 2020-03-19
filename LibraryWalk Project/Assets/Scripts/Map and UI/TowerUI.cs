using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUI : DragUI
{
    public Tower towerType;

    protected override void Holding(PointerEventData e, bool canDrop)
    {
        if (GetCurrency() < towerType.cost)
        {
            canDrop = false;
        }

        base.Holding(e, canDrop);
    }

    /// <summary>
    /// Drop tower only if construction can be afforded by player.
    /// </summary>
    protected override bool Drop(Vector3 pos)
    {
        // Check if player can afford
        if (GetCurrency() < towerType.cost)
        {
            if (carry && held) { Destroy(held.gameObject); }    // Remove temp obj
            return false;
        }

        bool result = base.Drop(pos);   // Try to drop tower

        if (result)
        {
            // Subtract cost if success 
            GameManager.instance.AddStaff(-towerType.cost);
        }

        return result;
    }

    int GetCurrency()
    {
        return GameManager.instance.GetStaff();
    }
}