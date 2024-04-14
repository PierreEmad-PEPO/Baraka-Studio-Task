using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float maxDeltaDistance;
    [SerializeField] Joystick rightJoystick;
    Vector3 endPos, rot;
    float horizontalInput, verticalInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = rightJoystick.Vertical;
        verticalInput = rightJoystick.Horizontal;
        rot.x -= horizontalInput * .7f;
        rot.y += verticalInput * .7f;
        transform.localEulerAngles = rot;

        if (Vector3.Distance(transform.position, playerTransform.position) > maxDeltaDistance) 
        {
            endPos = playerTransform.position;
            endPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, endPos, .7f);
        }
    }
}
