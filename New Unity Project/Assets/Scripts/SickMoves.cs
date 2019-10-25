using UnityEngine;
/*
 * Class that handles keyboard driven movement.
 */
public class SickMoves : MonoBehaviour
{
    //speed value for this gameObject
    public float mySpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        //create a vector to store the position of the object.
        Vector3 pos = transform.position;

        //checks if w key is pressed -> updates the vector storing position. 
        if (Input.GetKey("w"))
        {
            pos.y += mySpeed * Time.deltaTime;
        }
        //checks if s key is pressed -> updates the vector storing position. 
        if (Input.GetKey("s"))
        {
            pos.y -= mySpeed * Time.deltaTime;
        }
        //checks if d key is pressed -> updates the vector storing position. 
        if (Input.GetKey("d"))
        {
            pos.x += mySpeed * Time.deltaTime;
        }
        //checks if a key is pressed -> updates the vector storing position. 
        if (Input.GetKey("a"))
        {
            pos.x -= mySpeed * Time.deltaTime;
        }

       //sets the position of the object to the new vector
        transform.position = pos;
    }
}
