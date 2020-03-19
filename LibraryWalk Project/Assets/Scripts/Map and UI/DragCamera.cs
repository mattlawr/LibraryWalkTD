/**
 * DragCamera.cs
 * Class that handles camera dragging and zooming.
 * Author: Matthew Lawrence, some features adapted from BoundaryScroll
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Attatch this class to a camera that can be dragged around and zoomed in/out.
/// </summary>
public class DragCamera : MonoBehaviour
    /*, IPointerDownHandler
    , IPointerUpHandler
    , IDragHandler*/
{
    public float dragStrength = 1f;
    public float zoomStrength = 1f;

    public float minZoom = 5f;
    public float maxZoom = 20f;

    [Tooltip("Defines the area that the camera can view (world space).")]
    public Rect bounds = new Rect(Vector2.zero, new Vector2(10f, 6f));

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
        // Zooming
        float fov = cam.orthographicSize;
        fov -= Input.GetAxis("Mouse ScrollWheel") * zoomStrength * 2f;
        fov = Mathf.Clamp(fov, minZoom, maxZoom);
        cam.orthographicSize = fov;

        // Screen clicking
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

        Vector3 delta = PointerPos(Input.mousePosition) - PointerPos(initialPos);
        Vector3 newPos = initCamera - (delta * dragStrength);

        // If newPos is outside the bounds, clamp it
        if (!bounds.Contains(newPos)) {
            newPos = ClampRect(newPos, bounds);
        }

        transform.position = newPos;
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

    /// <summary>
    /// Bounds a vector to a rectangle.
    /// </summary>
    /// <param name="vector">The vector to change and return.</param>
    /// <param name="rect">Rect object for minimum and maximum bound data.</param>
    /// <returns>Bounded Vector3.</returns>
    public static Vector3 ClampRect(Vector3 vector, Rect rect)
    {
        vector.x = Mathf.Clamp(vector.x, rect.xMin, rect.xMax);
        vector.y = Mathf.Clamp(vector.y, rect.yMin, rect.yMax);

        return vector;
    }
}