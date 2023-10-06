using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;



//goal: freeze camera motion + show cursor
public class CatchMode : MonoBehaviour
{
    bool inCatchMode = false;

    
    // Start is called before the first frame update
     void Start()
    {
        Cursor.visible = false;    
    

    }

    // Update is called once per frame
    void Update()
    {
        // when player presses C, go into Catch Mode
        if(Input.GetKeyDown(KeyCode.C))
        {
            EnableCatchMode(!inCatchMode);
           
        }
 
         if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Right Mouse key was pressed.");
        }
        
    }

    void EnableCatchMode(bool shouldEnable)
    {   
        GetComponent<FirstPersonController>().enabled = !shouldEnable; 
        inCatchMode = shouldEnable;
        Cursor.visible = shouldEnable;

    }

}
