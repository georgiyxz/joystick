using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public GameObject cube;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get the current direction from the joystick
        Joystick.DIRECTION direction = joystick.Direction;

        // Move the player based on the joystick input
        MovePlayer(direction);
    }

    void MovePlayer(Joystick.DIRECTION direction)
    {
        if (direction != Joystick.DIRECTION.NONE)
        {
            Vector3 movement = Vector3.zero;

            // Determine the movement direction based on joystick input
            switch (direction)
            {
                case Joystick.DIRECTION.UP:
                    movement = Vector3.forward;
                    break;
                case Joystick.DIRECTION.DOWN:
                    movement = Vector3.back;
                    break;
                case Joystick.DIRECTION.LEFT:
                    movement = Vector3.left;
                    break;
                case Joystick.DIRECTION.RIGHT:
                    movement = Vector3.right;
                    break;
                default:
                    // No movement if the joystick is in the center or another direction is not recognized
                    break;
            }

            // Apply the movement to the player object
            cube.transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}