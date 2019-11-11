using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * Class that handles general drag and drop interaction for gameplay.
 * This script should allow towers to be moved and towers to be created from the toolbar.
 * By Matthew Lawrence
 */
public class DragUI : MonoBehaviour
    , IPointerDownHandler
    , IPointerUpHandler
{
    [Tooltip("The GameObject for this element to instantiate when dropped (leave null to target this GameObject).")]
    public GameObject drop = null;

    [Tooltip("The GameObject for this element to temporarily instantiate when being dragged (leave null to target this GameObject).")]
    public GameObject carry = null;

    private bool held = false;
    private Transform holdingTransform = null;
    private Vector3 initialPos;

    private void Update()
    {
        if (held)
        {
            Holding();// Update position of dragged transform.
        }
    }

    /**
     * Called while user is clicking on this DragUI element (works with EventSystem).
     */
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Click();
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Click();
    }

    /**
     * Called when clicked AND unclicked.
     */
    void Click()
    {
        if (held)
        {
            Drop(MousePos());
        }
        else
        {
            Pickup();
        }
    }

    /// <summary>
    /// Updates the position of the indicated transform to match the mouse position.
    /// </summary>
    void Holding()
    {
        holdingTransform.localPosition = MousePos();
    }

    /// <summary>
    /// Called when the user needs to grab the target for this object.
    /// </summary>
    public void Pickup()
    {
        initialPos = this.transform.localPosition;

        Transform t = this.transform;// Target this object
        if (carry)
        {
            GameObject c = GameObject.Instantiate(carry, null);// Instantiate temporary carry object
            t = c.transform;
        }

        // Subtract COST of tower/movement here...

        holdingTransform = t;
        held = true;
    }

    /// <summary>
    /// Places the target at the position of the mouse.
    /// </summary>
    void Drop(Vector3 pos)
    {
        Transform t = this.transform;// Target this object
        if (drop)
        {
            GameObject c = GameObject.Instantiate(drop, null);// Instantiate drop object
            t = c.transform;
            if (!carry) { this.transform.localPosition = initialPos; }
        }
        if(carry && holdingTransform) { Destroy(holdingTransform.gameObject); }// Remove temp obj

        t.localPosition = pos;
        held = false;
    }

    /// <summary>
    /// Gets the flattened World position of the Mouse.
    /// </summary>
    /// <returns>The Vector3 projection of the mouse position from the Screen.</returns>
    public static Vector3 MousePos()
    {
        Vector3 m = Input.mousePosition;
        return Vector3.Scale(Camera.main.ScreenToWorldPoint(m), new Vector3(1f, 1f, 0f));// Flattened vector
    }
}
