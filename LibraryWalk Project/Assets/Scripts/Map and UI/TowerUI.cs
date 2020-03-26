using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerUI : DragUI
{
    public Tower towerType;

    public Image image;
    public Text cost;

    public AudioSource pickupSound;
    public AudioSource placeSound;

    Color initColor;

    private void Start()
    {
        initColor = image.color;
        cost.text = towerType.cost + "";
    }

    protected override void Update()
    {
        if (!CanBuy())
        {
            image.color = Color.black;
        } else
        {
            image.color = initColor;
        }

        base.Update();
    }

    protected override void Pickup()
    {
        if (!CanBuy())
        {
            return;
        }

        base.Pickup();

        pickupSound.Play();
    }

    protected override void Holding(PointerEventData e, bool canDrop)
    {
        if (!CanBuy())
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
        if (!CanBuy())
        {
            if (carry && held) { Destroy(held.gameObject); }    // Remove temp obj
            return false;
        }

        bool result = base.Drop(pos);   // Try to drop tower

        if (result)
        {
            // Subtract cost if success 
            GameManager.instance.AddStaff(-towerType.cost);

            placeSound.Play();
        }

        return result;
    }

    int GetCurrency()
    {
        return GameManager.instance.GetStaff();
    }

    bool CanBuy()
    {
        return GetCurrency() >= towerType.cost;
    }
}