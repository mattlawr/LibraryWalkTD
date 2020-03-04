/**
 * DragUI.cs
 * Class that handles general drag and drop interaction for gameplay.
 * This script should allow towers to be moved and towers to be created from the toolbar.
 * Author: Matthew Lawrence
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Attatch this class to an object that needs to be dragged and dropped around the screen.
/// </summary>
public class DragCamera : MonoBehaviour
    /*, IPointerDownHandler
    , IPointerUpHandler
    , IDragHandler*/
{
    public float strength = 1f;
    
    private bool held = false;
    private Vector3 initialPos;
    private Vector3 initCamera;

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Down();
        }
        if (Input.GetMouseButton(1))
        {
            Hold();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Up();
        }
    }

    /**
     * Implementations of Unity UI handling (works with EventSystem).
     */
     /*
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Down();
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Up(PointerPos(eventData.position));
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Holding(eventData);
    }*/

    /// <summary>
    /// Updates the position of the transform to match the mouse position.
    /// </summary>
    void Hold()
    {
        if (!held) { return; }

        Vector3 delta = Input.mousePosition - initialPos;

        transform.position = initCamera - (delta * strength / 2f);
    }

    /// <summary>
    /// Called when the user needs to start dragging.
    /// </summary>
    void Down()
    {
        initialPos = Input.mousePosition;
        initCamera = transform.position;

        held = true;
    }

    /// <summary>
    /// Stops dragging.
    /// </summary>
    void Up()
    {
        held = false;
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