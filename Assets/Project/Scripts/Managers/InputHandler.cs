using System;
using UnityEngine;

public class InputHandler : Singleton<InputHandler> {

    public event Action MoveUp;
    public event Action MoveDown;
    public event Action MoveLeft;
    public event Action MoveRight;
    public event Action MoveUpDone;
    public event Action MoveDownDone;
    public event Action MoveLeftDone;
    public event Action MoveRightDone;
    public event Action<Vector3> Shoot;
    public event Action ConsumeCandle;

    [SerializeField]
    KeyCode MoveUpKey = KeyCode.W;
    [SerializeField]
    KeyCode MoveDownKey = KeyCode.S;
    [SerializeField]
    KeyCode MoveLeftKey = KeyCode.A;
    [SerializeField]
    KeyCode MoveRightKey = KeyCode.D;
    [SerializeField]
    KeyCode ConsumeCandleKey = KeyCode.E;

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
        if (Input.GetKeyUp(MoveUpKey))
        {
            OnMoveUpDone();
        }
        if (Input.GetKeyUp(MoveDownKey))
        {
            OnMoveDownDone();
        }
        if (Input.GetKeyUp(MoveLeftKey))
        {
            OnMoveLeftDone();
        }
        if (Input.GetKeyUp(MoveRightKey))
        {
            OnMoveRightDone();
        }
        if (Input.GetKeyDown(ConsumeCandleKey))
        {
            OnConsumeCandle();
        }
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
        }
    }

    void OnConsumeCandle() {
        if(ConsumeCandle != null)
        {
            ConsumeCandle();
        }
    }

    void OnShoot(Vector3 target)
    {
        if (Shoot != null)
        {
            Shoot(target);
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
        if(MoveRight != null)
        {
            MoveRight();
        }
    }

    void OnMoveUpDone()
    {
        if (MoveUpDone != null)
        {
            MoveUpDone();
        }
    }

    void OnMoveDownDone()
    {
        if (MoveDownDone != null)
        {
            MoveDownDone();
        }
    }

    void OnMoveLeftDone()
    {
        if (MoveLeftDone != null)
        {
            MoveLeftDone();
        }
    }

    void OnMoveRightDone()
    {
        if (MoveRightDone != null)
        {
            MoveRightDone();
        }
    }
}
