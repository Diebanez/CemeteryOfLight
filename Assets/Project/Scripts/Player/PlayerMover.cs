using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 5.0f;
    [SerializeField]
    Vector2 SpriteSize = new Vector2(4, 1.6f);
    [SerializeField]
    float ObliqueMovement = .65f;

    int layerMask;
    bool IsMovingRight = false;
    bool IsMovingUp = false;
    bool IsMovingDown = false;
    bool IsMovingLeft = false;
    SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        layerMask = ~(1 << (LayerMask.NameToLayer("Light")) | (1 << LayerMask.NameToLayer("Enemy")));
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        InputHandler.instance.MoveUp += OnMoveUp;
        InputHandler.instance.MoveDown += OnMoveDown;
        InputHandler.instance.MoveLeft += OnMoveLeft;
        InputHandler.instance.MoveRight += OnMoveRight;
        InputHandler.instance.MoveUpDone += OnMoveUpDone;
        InputHandler.instance.MoveDownDone += OnMoveDownDone;
        InputHandler.instance.MoveLeftDone += OnMoveLeftDone;
        InputHandler.instance.MoveRightDone += OnMoveRightDone;
    }

    void OnDestroy()
    {
        InputHandler.instance.MoveUp -= OnMoveUp;
        InputHandler.instance.MoveDown -= OnMoveDown;
        InputHandler.instance.MoveLeft -= OnMoveLeft;
        InputHandler.instance.MoveRight -= OnMoveRight;
        InputHandler.instance.MoveUpDone -= OnMoveUpDone;
        InputHandler.instance.MoveDownDone -= OnMoveDownDone;
        InputHandler.instance.MoveLeftDone -= OnMoveLeftDone;
        InputHandler.instance.MoveRightDone -= OnMoveRightDone;
    }

    private void Update()
    {
        if (IsMovingRight)
        {
            if (IsMovingUp)
            {
                transform.Translate(new Vector2(ObliqueMovement, ObliqueMovement) * MovementSpeed * Time.deltaTime);
            }else if (IsMovingDown)
            {
                transform.Translate(new Vector2(ObliqueMovement, -ObliqueMovement) * MovementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector2(1.0f, 0.0f) * MovementSpeed * Time.deltaTime);
            }
        }
        else if (IsMovingLeft)
        {
            if (IsMovingUp)
            {
                transform.Translate(new Vector2(-ObliqueMovement, ObliqueMovement) * MovementSpeed * Time.deltaTime);
            }
            else if (IsMovingDown)
            {
                transform.Translate(new Vector2(-ObliqueMovement, -ObliqueMovement) * MovementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector2(-1.0f, 0.0f) * MovementSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (IsMovingUp)
            {
                transform.Translate(new Vector2(0.0f, 1.0f) * MovementSpeed * Time.deltaTime);
            }
            else if (IsMovingDown)
            {
                transform.Translate(new Vector2(0.0f, -1.0f) * MovementSpeed * Time.deltaTime);
            }
        }
    }

    void OnMoveUp()
    {        
        if (!Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + .01f) + new Vector2(0, SpriteSize.y), Vector2.up, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + .01f) + new Vector2(-SpriteSize.x / 2, SpriteSize.y), Vector2.up, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + .01f) + new Vector2(+SpriteSize.x / 2, SpriteSize.y), Vector2.up, .1f, layerMask))
        {
            IsMovingUp = true;
        }
        else
        {
            IsMovingUp = false;
        }
    }

    void OnMoveDown()
    {
        if (!Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .01f), -Vector2.up, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .01f) + new Vector2(-SpriteSize.x / 2, 0), -Vector2.up, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .01f) + new Vector2(+SpriteSize.x / 2, 0), -Vector2.up, .1f, layerMask))
        {
            IsMovingDown = true;
        }
        else
        {
            IsMovingDown = false;
        }
    }

    void OnMoveLeft()
    {
        if (!Physics2D.Raycast(new Vector2(transform.position.x - .01f, transform.position.y) + new Vector2(-SpriteSize.x / 2, 0), -Vector2.right, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x - .01f, transform.position.y) + new Vector2(-SpriteSize.x / 2, SpriteSize.y), -Vector2.right, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x - .01f, transform.position.y) + new Vector2(-SpriteSize.x / 2, SpriteSize.y/2), -Vector2.right, .1f, layerMask))
        {
            IsMovingLeft = true;
        }
        else
        {
            IsMovingLeft = false;
        }
    }

    void OnMoveRight()
    {
        if (!Physics2D.Raycast(new Vector2(transform.position.x + .01f, transform.position.y) + new Vector2(SpriteSize.x / 2, 0), Vector2.right, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x + .01f, transform.position.y) + new Vector2(SpriteSize.x / 2, SpriteSize.y), Vector2.right, .1f, layerMask) &&
            !Physics2D.Raycast(new Vector2(transform.position.x + .01f, transform.position.y) + new Vector2(SpriteSize.x / 2, SpriteSize.y / 2), Vector2.right, .1f, layerMask))
        {
            IsMovingRight = true;
        }
        else
        {
            IsMovingRight = false;
        }
    }

    void OnMoveUpDone()
    {
        IsMovingUp = false;
    }

    void OnMoveDownDone()
    {
        IsMovingDown = false;
    }

    void OnMoveLeftDone()
    {
        IsMovingLeft = false;
    }

    void OnMoveRightDone()
    {
        IsMovingRight = false;
    }
}