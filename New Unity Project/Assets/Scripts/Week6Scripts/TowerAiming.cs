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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trackedObjects.Add(collision.gameObject);
    }

    void FixedUpdate()
    {
        minDistCurr = float.MaxValue;
        //handle checking state of curTarget 
        if (curTarget != null)
        {
            if (!isInRange(curTarget))
            {
                curTarget = null;
            }
        }
        else
        {
            //handle iterating through tracked objects
            int counter = 0;
            foreach (GameObject cur in trackedObjects)
            {
                //handle null object case 
                if (cur == null)
                {
                    trackedObjects.RemoveAt(counter);
                    counter--;
                }
                //handle whether or not object is an enemy 
                else if (cur.tag != "EnemyType")
                {
                    trackedObjects.RemoveAt(counter);
                    counter--;
                }
                //check whether on not the enemy is range
                else if (!isInRange(cur))
                {
                    trackedObjects.RemoveAt(counter);
                    counter--;
                }
                else
                {
                    float curDist = Mathf.Abs(Vector3.Distance(cur.transform.position, transform.position));
                    if (curDist < minDistCurr)
                    {
                        minDistCurr = curDist;
                        curTarget = cur;
                    }
                }
                counter++;
            }
        }
        //Debug.Log("FixedUpdate time :" + Time.deltaTime);
        if (curTarget != null)
        {
            //handle shooting here
        }
    }


    //Checks if an object is within range of the tower. 
    public  bool isInRange(GameObject other)
    {
        bool resultant = false;
        //transform.position 
        if (Mathf.Abs(Vector3.Distance(other.transform.position, transform.position)) < myAttackRange)
        {
            resultant = true; 
        }
        return resultant; 
    }

}
