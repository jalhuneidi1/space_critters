//[OLD]Description: This script controls the movement of the character, including walking, jumping, and swinging the arm.
//[NEW]Description: This script controls arm movement of player.

using UnityEngine;

public class ArmController : MonoBehaviour
{
    // Public variables that can be set in the Unity editor.

    // The speed at which the character moves.
    // public float movementSpeed = 5f;

    // The Animator component on the character object.
    public Animator armAnimator;

    // The current rotation of the arm (I think?)
    public float armRotation;

    // The speed at which the arm swings.
    public float armSwingSpeed = 5f;

    // Private variables that are used internally by the script.

    // The CharacterController component on the character object.
    private CharacterController characterController;

    // A boolean variable to track whether the arm is swinging.
    private bool isSwingingArm = false;

    // Start is called before the first frame update.
    private void Start()
    {
        // Get the CharacterController component on the character object.
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Swing the character's arm up and down using the mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            isSwingingArm = true;
        }

        // If the arm is swinging, then rotate the arm up and down using the armSwingSpeed variable.
        if (isSwingingArm)
        {
            float armRotation = armAnimator.GetFloat("ArmRotation");
            armRotation += armSwingSpeed * Time.deltaTime;
            armAnimator.SetFloat("ArmRotation", armRotation);
        }

        // If the arm rotation reaches a certain point, then stop swinging the arm.
        if (armRotation >= 90f)
        {
            isSwingingArm = false;
        }
    }
}
