using System;
using UnityEngine;

public class InputHandler : Singleton<InputHandler> {
    public event Action MoveUp;
    public event Action MoveDown;
    public event Action MoveLeft;
    public event Action MoverRight;

    [SerializeField]
    KeyCode MoveUpKey = KeyCode.W;
    [SerializeField]
    KeyCode MoveDownKey = KeyCode.S;
    [SerializeField]
    KeyCode MoveLeftKey = KeyCode.A;
    [SerializeField]
    KeyCode MoveRightKey = KeyCode.D;

    void Update()
    {
        if (Input.GetKey(MoveUpKey))
        {
            OnMoveUp();
        }
        if (Input.GetKey(MoveDownKey))
        {
            OnMoveDown();
        }
        if (Input.GetKey(MoveLeftKey))
        {
            OnMoveLeft();
        }
        if (Input.GetKey(MoveRightKey))
        {
            OnMoveRight();
        }
    }

    void OnMoveUp()
    {
        if(MoveUp != null)
        {
            MoveUp();
        }
    }

    void OnMoveDown()
    {
        if(MoveDown != null)
        {
            MoveDown();
        }
    }

    void OnMoveLeft()
    {
        if(MoveLeft != null)
        {
            MoveLeft();
        }
    }

    void OnMoveRight()
    {
        if(MoverRight != null)
        {
            MoverRight();
        }
    }
}
