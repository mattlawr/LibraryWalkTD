
using UnityEngine; //access unity built in functions

public class TestScript : MonoBehaviour
{
    //some string declerations for fun
<<<<<<< HEAD
    public string yourName = "Ervey Del Rosario";
=======
    public string yourName = "Javier";
>>>>>>> 38821f9d44e7158a0321028424aba35ebc888b95
    private string myPrivateString = "open";
    private int counter = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Wow you can " + myPrivateString +  " scripts: " + yourName);
        /*
        if (isVisualStudioGood()) {
            Debug.Log("Visual studio is pretty good.");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //incremement counter
        counter++;
        int framesIWantToCount = 30; 
        //check if counter is five
        if (counter == framesIWantToCount)
        {
            //reset counter and log progress
            counter = 0;
            LogFramesPassed();
            Debug.Log("Five frames have passed");
            LogNumberFramesPassed(framesIWantToCount);
        }
    }

    /*
    * LogFramesPassed prints out that some frames have passed 
    * Parameters: None
    * Returns: None
    */
    void LogFramesPassed()
    {
        Debug.Log("Some frames have passed");
    }

    /*
    * LogNumberFramesPassed prints out a number of frames that has passed
    * Parameters: Interger value
    * Returns: None
    */
    void LogNumberFramesPassed(int val)
    {
        Debug.Log(val+"Some frames have passed");
    }

    /*
     * isVisualStudioGood assesses whether or not visual studio is a good product
     * Parameters: None
     * Returns: Boolean value
     */
    bool isVisualStudioGood()
    {
        return true;
    }

}
