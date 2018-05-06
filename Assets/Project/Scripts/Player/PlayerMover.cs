using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 5.0f;

    void Start()
    {
        InputHandler.instance.MoveUp += OnMoveUp;
        InputHandler.instance.MoveDown += OnMoveDown;
        InputHandler.instance.MoveLeft += OnMoveLeft;
        InputHandler.instance.MoveRight += OnMoveRight;
    }

    void OnDestroy()
    {
        InputHandler.instance.MoveUp -= OnMoveUp;
        InputHandler.instance.MoveDown -= OnMoveDown;
        InputHandler.instance.MoveLeft -= OnMoveLeft;
        InputHandler.instance.MoveRight -= OnMoveRight;
    }

    void OnMoveUp()
    {
        transform.Translate(transform.up * MovementSpeed * Time.deltaTime);
    }

    void OnMoveDown()
    {
        transform.Translate(-transform.up * MovementSpeed * Time.deltaTime);
    }

    void OnMoveLeft()
    {
        transform.Translate(-transform.right * MovementSpeed * Time.deltaTime);
    }

    void OnMoveRight()
    {
        transform.Translate(transform.right * MovementSpeed * Time.deltaTime);
    }
}