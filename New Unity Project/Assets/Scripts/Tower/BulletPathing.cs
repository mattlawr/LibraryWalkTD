using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPathing : MonoBehaviour
{
    public float mySpeed = 2.5f;
    public GameObject targ;
  
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, mySpeed);
    }

    public void setTarg(GameObject newTarget)
    {
        targ = newTarget;
    }
}
