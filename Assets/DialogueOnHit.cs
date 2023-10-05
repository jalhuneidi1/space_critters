using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOnHit : MonoBehaviour
{
   // what variables do we need?

    bool isStoodInFront = false;
    public string dialogueToSay;
    
    //the lil' box called Text
    [SerializeField] Text dialogueWidget;

    // Function to despawn 'bugs' OnTrigger?
    // Function to despawn bugs on keyclick E

  
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        isStoodInFront = true;
        Debug.Log("You've found the bug!");
    }
    //make a debug log instead..? put this on UI


    private void Update()
    {
        if(isStoodInFront && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("You've caught the bug!");
            //put this on UI also
        }
    }
}
