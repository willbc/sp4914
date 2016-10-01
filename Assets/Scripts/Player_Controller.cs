using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Player_Controller : MonoBehaviour {

    float walkingSpeed = 4.0f;
    float runningSpeed = 18.0f;
    float jumpSpeed = 4.0f;
    float verticalSpeedLimit = 11000.0f;

    float mouseSensitivity = 1.0f;
    float pitchRange = 60.0f;

    public Camera camera;
    CharacterController characterController;
    float forwardInput;
    float lateralInput;
    float yawInput; // left-right
    float pitchInput; // up-down
    float pitchRotation = 0;
    bool isRunning;

    Vector3 movement;

    float verticalSpeed = 0.0f;
    float currentSpeed = 0.0f;


	void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	void Update () {
        forwardInput = Input.GetAxis("Vertical");
        //Debug.Log(forwardInput);
        lateralInput = Input.GetAxis("Horizontal");
        //Debug.Log(lateralInput);
        yawInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        pitchInput = Input.GetAxis("Mouse Y") * mouseSensitivity;
        isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(isRunning) {
            currentSpeed = runningSpeed;
        }
        else {
            currentSpeed = walkingSpeed;
        }

        transform.Rotate(0.0f, yawInput, 0.0f);

        pitchRotation -= pitchInput;
        pitchRotation = Mathf.Clamp(pitchRotation, -pitchRange, pitchRange);

        camera.transform.localRotation = Quaternion.Euler(pitchRotation, 0.0f, 0.0f);

        verticalSpeed += Physics.gravity.y * Time.deltaTime;
    
        if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
            verticalSpeed = jumpSpeed;
        }

        Mathf.Clamp (verticalSpeed, -verticalSpeedLimit, verticalSpeedLimit);

        if (characterController.isGrounded) {
            movement.Set (lateralInput * currentSpeed, verticalSpeed, forwardInput * currentSpeed);
        } else {
            movement.Set (lateralInput * currentSpeed / 1.5f, verticalSpeed, forwardInput * currentSpeed / 1.5f);
        }

        movement = transform.rotation * movement;

        characterController.Move ( movement * Time.deltaTime );
    }
}
