using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCritters : MonoBehaviour
{
    // Reference to the main camera
    private Camera camera;

    // Public variable to assign the critter prefab
    // public GameObject critterPrefab;

    // Public variable to set the distance for raycasting
    public float distanceFromBug = 5f;

    // Boolean to track whether the player is in catch mode
    private bool inCatchMode = false;

    // Sound effect for when a bug is caught
    // public AudioClip catchSound;

    // Update is called once per frame
    void Update()
    {
        // Check for the 'C' button press to toggle catch mode
        // if (Input.GetButtonDown("C"))
        {
            //ToggleCatchMode();
        }

        // Check if in catch mode
        if (inCatchMode)
        {
            // Check for the 'C' button press to catch bugs
            if (Input.GetKeyDown(KeyCode.Mouse0)) // Change "Fire1" to your desired catch input
            {
                CatchBug();
            }
        }
    }

    void CatchBug()
    {
        //make critter prefab disappear - oncollision 
        //turn critter boolean to true to trigger journal entry
        //line to retrieve script + retrieve booleans
        //if critter's collision box is detected by raycast, set their bool to true

        // Create a ray from the camera's position in the forward direction
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        // Check if the ray hits anything within the specified distance
        if (Physics.Raycast(ray, out RaycastHit hit, distanceFromBug))
        {
            if (hit.collider.gameObject.tag == "caterpillar")
            {
                JournalScript.isCaterpillarCaught = true;
                Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.gameObject.tag == "damselfly")
            {
                JournalScript.isDamselflyCaught = true;
                Destroy(hit.collider.gameObject);
            }

            // Check if the hit object has a Target script attached
            //if (hit.transform.TryGetComponent<CaterpillarRainbow>(out CaterpillarRainbow critterType1Script))
            {
                // Call the GetShot function and pass the direction of the ray
                //targetScript.GetShot(ray.direction);
            }
            //else if (hit.transform.TryGetComponent<DamselflyAlien>(out DamselflyAlien critterType2Script))
            {
                //critterType2Script.GetShot();
            }
            //else if (hit.transform.TryGetComponent<CritterType3>(out CritterType3 critterType3Script))
            {
                // critterType3Script.GetShot();
            }
            // Play catch sound
            // AudioSource.PlayClipAtPoint(catchSound, hit.point);

                // Destroy the caught bug
                // Destroy(hit.collider.gameObject);
            
        }
    }

    // Function that takes in the direction of the ray and adds force to the bug
    // goes to raycast component to check if it has that target on it
    public void GetShot(Vector3 direction)
    {
        // simulates physical interaction between objects
        Vector3 force = direction * 5 + Vector3.up * 10;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

       // detatch object from parent, making it an independent object
        transform.parent = null;
        Debug.Log("Critter has been caught!");
    }

    // Function to toggle catch mode
   public void ToggleCatchMode()
    {
        inCatchMode = !inCatchMode;
        Cursor.visible = inCatchMode; // Show or hide the cursor based on catch mode
    }
}
