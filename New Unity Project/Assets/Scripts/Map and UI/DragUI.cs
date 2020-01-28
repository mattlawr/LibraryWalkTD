using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
 * DragUI.cs
 * Class that handles general drag and drop interaction for gameplay.
 * This script should allow towers to be moved and towers to be created from the toolbar.
 * By Matthew Lawrence
 */
public class DragUI : MonoBehaviour
    , IPointerDownHandler
    , IPointerUpHandler
    , IDragHandler
{
    static readonly float Y_MIN = -2f;

    [Tooltip("The GameObject for this element to instantiate when dropped (leave null to target this GameObject).")]
    public GameObject drop = null;

    [Tooltip("The GameObject for this element to temporarily instantiate when being dragged (leave null to target this GameObject).")]
    public GameObject carry = null;

    private Transform held = null;
    private Vector3 initialPos;

    private void Update()
    {

    }

    /**
     * Implementations of Unity UI handling (works with EventSystem).
     */
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pickup();
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Drop(PointerPos(eventData.position));
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Holding(eventData);
    }

    /// <summary>
    /// Updates the position of the indicated transform to match the mouse position.
    /// </summary>
    void Holding(PointerEventData e)
    {
        Vector3 pos = PointerPos(e.position);
        held.localPosition = pos;

        SpriteRenderer sr = held.GetComponent<SpriteRenderer>();
        if (pos.y < Y_MIN && sr)
        {
            //print(pos);
            sr.color = Color.red;
        } else if(sr)
        {
            sr.color = Color.green;
        }
    }

    /// <summary>
    /// Called when the user needs to grab the target for this object.
    /// </summary>
    public void Pickup()
    {
        initialPos = this.transform.position;

        Transform t = this.transform;// Target this object
        if (carry)
        {
            GameObject c = GameObject.Instantiate(carry, initialPos, Quaternion.identity, null);// Instantiate temporary carry object
            t = c.transform;
        }
        

        held = t;
    }

    /// <summary>
    /// Places the target at the position of the mouse.
    /// </summary>
    void Drop(Vector3 pos)
    {
        Transform t = this.transform;// Target this object

        if (carry && held) { Destroy(held.gameObject); }// Remove temp obj
        if (drop && pos.y >= Y_MIN)
        {
            GameObject c = GameObject.Instantiate(drop, null);// Instantiate drop object
            t = c.transform;
            if (!carry) { this.transform.localPosition = initialPos; }
        } else if(pos.y < Y_MIN)
        {
            //cancel drop and cost
            return;
        }

        // Subtract COST of tower/movement here...

        t.localPosition = pos;
    }

    /// <summary>
    /// Gets the flattened World position of the screen position.
    /// </summary>
    /// <returns>The Vector3 projection of the pointer position from the Screen.</returns>
    public static Vector3 PointerPos(Vector2 point)
    {
        Vector3 m = point;
        return Vector3.Scale(Camera.main.ScreenToWorldPoint(m), new Vector3(1f, 1f, 0f));// Flattened vector
    }
}

class Stretch
{
    private float strength;

    private Transform transform;

    public Stretch(Transform t, float strength)
    {
        transform = t;
        this.strength = strength;
    }

    /**
     * Called every frame to update transform
     */
    public void StretchUpdate(Vector3 delta)
    {

    }

    // TBD
}