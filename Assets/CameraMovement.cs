using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public Joystick joystick;
    public GameObject cube;
    public float rotationSpeed = 100f;
    private float cumulativeRotation = 0f;

    private Camera playerCamera;

    void Start()
    {
        playerCamera = cube.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Get the current direction from the joystick
        Joystick.DIRECTION direction = joystick.Direction;

        // Rotate the cube with the camera based on the joystick input
        RotateCamera(direction);
    }

    void RotateCamera(Joystick.DIRECTION direction)
    {
        if (direction == Joystick.DIRECTION.LEFT)
        {
            cube.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (direction == Joystick.DIRECTION.RIGHT)
        {
            cube.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
    // Rotate the cube with the camera based on the joystick input
    // playerCamera.transform.RotateAround(cube.transform.position, Vector3.up, verticalInput * rotationSpeed * Time.deltaTime);

    // Update the cumulative rotation
    // cumulativeRotation += verticalInput * rotationSpeed * Time.deltaTime;


    // Make the camera look at the cube with the cumulative rotation applied
    //  playerCamera.transform.rotation = Quaternion.Euler(0f, cumulativeRotation, 0f);
}
