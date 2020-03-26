using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    //state variables
    public double range;
    //public int multishot;
    public GameObject target;
    public int attackDelay;

    public GameObject Bullet;

    private int internalTimer = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        internalTimer++;
        if (internalTimer == attackDelay)
        {
            Vector3 targetPos = target.transform.position;
            if (checkRange(targetPos))
            {
                GameObject tempBulletHandler;
                tempBulletHandler = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
                //BulletPathing tempBulletPathing;
                //tempBulletPathing = tempBulletHandler.GetComponent<BulletPathing>();
                //tempBulletPathing.setTarg(target);
                //set the bullets to yeet themeselves 
                Destroy(tempBulletHandler, 3.0f);
            }
            internalTimer = 0;
        }
    }

    /*
     * checkRange() 
     * 
     */
    bool checkRange(Vector3 targetLocation)
    {
        bool resultant = false;
        float distToTarget = Vector3.Distance(targetLocation, transform.position);
        if (Mathf.Abs(distToTarget) < range) 
        {
            resultant = true; 
        }  
        return resultant; 
    }
}
