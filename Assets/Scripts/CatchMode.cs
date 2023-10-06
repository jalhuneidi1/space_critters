using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

/*
* Description: Mechanics that enables player to interact with 
* creatures in game and enables/disables bug-catching mechanics 
*/

//goal: freeze camera motion + show cursor
public class CatchMode : MonoBehaviour
{
    // Disable bug catching mode
        bool inCatchMode = false;

    
    // Start is called before the first frame update
     void Start()
    {
        // Hide the cursor 
        Cursor.visible = false;    
    

    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player presses the 'C' to toggle Catch mode
        if(Input.GetKeyDown(KeyCode.C))
        {
            // Sets inCatchMode boolean value to true
            EnableCatchMode(!inCatchMode);
           
        }
 
        // Check if the player presses the right mouse button
         if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Log message when right button is pressed
            Debug.Log("Right Mouse key was pressed.");
        }
        
    }

    // Function to enable or diable Catch Mode
    void EnableCatchMode(bool shouldEnable)
    {   
        //Toggle the FirstPersonController component based on the given parameter
        GetComponent<FirstPersonController>().enabled = !shouldEnable; 

        // Update the inCatchMode variable
        inCatchMode = shouldEnable;

        // Toggle the visibility of the cursor based on the given parameter
        Cursor.visible = shouldEnable;

    }

}
