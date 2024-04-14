using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Joystick leftJoystick;
    Vector3 rot;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = leftJoystick.Horizontal;
        float verticalInput = leftJoystick.Vertical;

        rot = transform.localEulerAngles;
        rot.y = cameraTransform.localEulerAngles.y;
        transform.localEulerAngles = rot;
        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        moveDirection = (forwardMovement + rightMovement).normalized * moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
