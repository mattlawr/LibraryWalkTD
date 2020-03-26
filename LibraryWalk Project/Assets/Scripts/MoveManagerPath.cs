
using UnityEngine;

public class MoveManagerPath : MonoBehaviour
{
    // Public variables indicating spots along the desired path
    public float pointOneX = 0f;
    public float pointOneY = 0f;
    public float pointTwoX = 0f;
    public float pointTwoY = 0f;
    public float pointThreeX = 0f;
    public float pointThreeY = 0f;
    public float pointFourX = 0f;
    public float pointFourY = 0f;
    public int numPoints = 4; 
    //speed and loop variables
    public float mySpeed = 0.1f; 
    public bool isLoop = false; 

    //keeps track of what point we should be going to
    private int targetPoint = 0;
    //keeps track of point position we should be going to. 
    private float curPointX = 0f;
    private float curPointY = 0f;
    private Vector3 targetPositionVector;
    void Start()
    {
        //set the path variables 
        curPointX = pointOneX;
        curPointY = pointOneY;
        targetPoint = 0;
        //give the reference target vector value.
        targetPositionVector = new Vector3(curPointX, curPointY, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (targetPoint != -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositionVector, mySpeed);
            float dist = Vector3.Distance(transform.position, targetPositionVector);
            //check if the next movement would pass the target point.
            Debug.Log("dist:" + Mathf.Abs(dist));
            if (Mathf.Abs(dist) < mySpeed)
            {
                setNewTargetLocation(++targetPoint);
            }
        }
    }

    void setNewTargetLocation(int nextPoint)
    {
        Debug.Log("x:" + curPointX);
        Debug.Log("y:" + curPointX);
        if (nextPoint >= numPoints && isLoop)
        {
            nextPoint = nextPoint % numPoints;
        } 
        else if (nextPoint >= numPoints)
        {
            //do nothing 
            targetPoint = -1;
        }

        if (nextPoint == 0)
        {
            curPointX = pointOneX;
            curPointY = pointOneY;
            targetPoint = 0;
        }
        else if (nextPoint == 1)
        {
            curPointX = pointTwoX;
            curPointY = pointTwoY;
            targetPoint = 1;
        }
        else if (nextPoint == 2)
        {
            curPointX = pointThreeX;
            curPointY = pointThreeY;
            targetPoint = 2;
        }
        else if (nextPoint == 3)
        {
            curPointX = pointFourX;
            curPointY = pointFourY;
            targetPoint = 3;
        }
        targetPositionVector = new Vector3(curPointX, curPointY, 0);
    }
}
