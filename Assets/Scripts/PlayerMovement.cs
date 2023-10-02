//Description: This script controls the movement of the character, including walking, jumping, and swinging the arm.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables that can be set in the Unity editor.

    // The speed at which the character moves.
    public float movementSpeed = 5f;

    // The Animator component on the character object.
    public Animator armAnimator;

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
        // Move the character using the WASD or arrow keys.
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(horizontalMovement, 0, verticalMovement);
        characterController.Move(movementVector * movementSpeed * Time.deltaTime);

        // Make the character jump using the space key.
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            characterController.Move(new Vector3(0, 5f, 0));
        }

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
