using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScroll : MonoBehaviour
{
    public int Boundary = 50;
    public int speed = 10;
    private int theScreenWidth;
    private int theScreenHeight;
    // Start is called before the first frame update
    private Vector3 transform;

    void Start()
    {
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
        transform = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > theScreenWidth - Boundary && Camera.main.transform.position.x < 49.0f)
        {
            transform.x += speed * Time.deltaTime; // move on +X axis
        }
        if (Input.mousePosition.x < 0 + Boundary && Camera.main.transform.position.x > -70.0f)
        {
            transform.x -= speed * Time.deltaTime; // move on -X axis
        }
        if (Input.mousePosition.y > theScreenHeight - Boundary && Camera.main.transform.position.y < 11.0f)
        {
            transform.y += speed * Time.deltaTime; // move on +Z axis
        }
        if (Input.mousePosition.y < 0 + Boundary && Camera.main.transform.position.y > -10.0f)
        {
            transform.y -= speed * Time.deltaTime; // move on -Z axis
        }
        Camera.main.transform.position = transform;
    }
}
