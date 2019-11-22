using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAiming : MonoBehaviour
{
    //GameObject myManager = GetComponent<TowerManager>();
    // Start is called before the first frame update
    List<GameObject> trackedObjects = new List<GameObject>();
    GameObject curTarget = null;
    private float minDistCurr;
    public float myAttackRange = 0.8f;
    CircleCollider2D myRadiusCollider; 

    
    //obtains reference to circle collider we will be using to track range. 
    private void Start()
    {
        myRadiusCollider = GetComponent<CircleCollider2D>();
        myRadiusCollider.radius = myAttackRange;
    }
    
    //handles mapping collisions with radiunce object. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name+"is in range");
        trackedObjects.Add(collision.gameObject);
    }

    //handles state of tower aiming
    void FixedUpdate()
    { 
        minDistCurr = float.MaxValue;
        //handle checking state of curTarget 
        if (curTarget != null)
        {
            bool validRange = isInRange(curTarget);
            Debug.Log("Is In Range" + validRange);
            if (validRange == false)
            {
                curTarget = null;
            }
        }
        else
        {
            //handle iterating through tracked objects
            foreach (GameObject cur in trackedObjects)
            {
                //handle null object case 
                float curDist = Mathf.Abs(Vector3.Distance(cur.transform.position, transform.position));
                if (curDist < minDistCurr && curTarget == null)
                {
                    minDistCurr = curDist;
                    curTarget = cur;
                }
            }
        }
        //Debug.Log("FixedUpdate time :" + Time.deltaTime);
        if (curTarget != null)
        {
            //handle shooting here
            
        }
        else
        {
           // Debug.Log("No Current Target");
        }
       
    }


    //Checks if an object is within range of the tower. 
    public  bool isInRange(GameObject other)
    {
        if (Mathf.Abs(Vector3.Distance(other.transform.position, transform.position)) < myAttackRange)
        {
            return true; 
        }
        return false; 
    }

}
