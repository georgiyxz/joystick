using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class SwipeManager : MonoBehaviour
{
    public static SwipeManager Instance;

    public enum SwipeDirection { NONE, TAP, LEFT, UP, RIGHT, DOWN}

    private InputManager inputManager;

    private SwipeDirection swipeDirection;
    public SwipeDirection Direction { get { return swipeDirection; } }

    private Vector2 startTouchPos;
    private Vector2 currentTouchPos;
    private Vector2 endTouchPos;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    int currentSwipeID = int.MinValue;

    bool enableSwipes;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            EnableSwipes(true);
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        inputManager = InputManager.Instance;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        // Subscribe to the OnStartTouchEvent
        inputManager.OnStartTouch += StartTouch;
        inputManager.OnEndTouch += EndTouch;
        inputManager.OnTouchMoved += TouchMoved;
    }

    public void EnableSwipes(bool b)
    {
        enableSwipes = b;
    }

    private void OnDisable()
    {
        if (inputManager == null) return;
        // Subscribe to the OnStartTouchEvent
        inputManager.OnStartTouch -= StartTouch;
        inputManager.OnEndTouch -= EndTouch;
        inputManager.OnTouchMoved -= TouchMoved;
    }

    private void StartTouch(Finger finger, float time)
    {
        if (!enableSwipes) return;
        if (currentSwipeID != int.MinValue) return;

        currentSwipeID = finger.index;
        startTouchPos = finger.screenPosition;
    }

    private void TouchMoved(Finger finger, float time)
    {
        if (!enableSwipes) return;
        if (currentSwipeID != finger.index) return;

        currentTouchPos = finger.screenPosition;
        Vector2 dist = currentTouchPos - startTouchPos;

        if (!stopTouch)
        {
            if (dist.x < -swipeRange)
            {
                swipeDirection = SwipeDirection.LEFT;
                stopTouch = true;
            }
            else if (dist.x > swipeRange)
            {
                swipeDirection = SwipeDirection.RIGHT;
                stopTouch = true;
            }
            else if (dist.y > swipeRange)
            {
                swipeDirection = SwipeDirection.UP;
                stopTouch = true;
            }
            else if (dist.y < -swipeRange)
            {
                swipeDirection = SwipeDirection.DOWN;
                stopTouch = true;
            }
        }
    }

    private void EndTouch(Finger finger, float time)
    {
        if (!enableSwipes) return;
        if (currentSwipeID != finger.index) return;

        currentSwipeID = int.MinValue;
        stopTouch = false;

        if(Input.touches.Length > 0)
        endTouchPos = Input.GetTouch(0).position;
        Vector2 dist = endTouchPos - startTouchPos;

        if (Mathf.Abs(dist.x) < tapRange && Mathf.Abs(dist.y) < tapRange)
        {
            swipeDirection = SwipeDirection.TAP;
        }
    }
}
