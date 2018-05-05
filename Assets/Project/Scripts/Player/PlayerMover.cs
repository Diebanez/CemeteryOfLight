using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 5.0f;

    CharacterController m_CharacterController;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        InputHandler.instance.MoveUp += OnMoveUp;
        InputHandler.instance.MoveDown += OnMoveDown;
        InputHandler.instance.MoveLeft += OnMoveLeft;
        InputHandler.instance.MoverRight += OnMoveRight;
    }

    void OnDestroy()
    {
        InputHandler.instance.MoveUp -= OnMoveUp;
        InputHandler.instance.MoveDown -= OnMoveDown;
        InputHandler.instance.MoveLeft -= OnMoveLeft;
        InputHandler.instance.MoverRight -= OnMoveRight;
    }

    void OnMoveUp()
    {
        m_CharacterController.Move(transform.up * MovementSpeed * Time.deltaTime);
    }

    void OnMoveDown()
    {
        m_CharacterController.Move(-transform.up * MovementSpeed * Time.deltaTime);
    }

    void OnMoveLeft()
    {
        m_CharacterController.Move(-transform.right * MovementSpeed * Time.deltaTime);
    }

    void OnMoveRight()
    {
        m_CharacterController.Move(transform.right * MovementSpeed * Time.deltaTime);
    }
}