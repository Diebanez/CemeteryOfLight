using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour {
    
    [SerializeField]
    RuntimeAnimatorController HighAnimator;
    [SerializeField]
    RuntimeAnimatorController MidAnimator;
    [SerializeField]
    RuntimeAnimatorController LowAnimator;

    Animator m_AnimatorController;
    PlayerWax m_WaxController;
    PlayerLight m_LightController;

    private void Start()
    {
        m_WaxController = GetComponentInParent<PlayerWax>();
        m_LightController = GetComponentInParent<PlayerLight>();
        m_AnimatorController = GetComponent<Animator>();
        InputHandler.instance.MoveUp += OnMoveUp;
        InputHandler.instance.MoveDown += OnMoveDown;
        InputHandler.instance.MoveLeft += OnMoveLeft;
        InputHandler.instance.MoveRight += OnMoveRight;
        InputHandler.instance.MoveUpDone += OnMoveUpDone;
        InputHandler.instance.MoveDownDone += OnMoveDownDone;
        InputHandler.instance.MoveLeftDone += OnMoveLeftDone;
        InputHandler.instance.MoveRightDone += OnMoveRightDone;
    }

    private void Update()
    {
        m_AnimatorController.SetBool("LightOn", m_LightController.IsLightOn);
        if (m_WaxController.Wax <= 20) {
            m_AnimatorController.runtimeAnimatorController = LowAnimator;
        }
        else if (m_WaxController.Wax <= 50)
        {
            m_AnimatorController.runtimeAnimatorController = MidAnimator;
        }
        else
        {
            m_AnimatorController.runtimeAnimatorController = HighAnimator;
        }
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

    void OnMoveUp()
    {
        m_AnimatorController.SetBool("MovingUp", true);
    }

    void OnMoveDown()
    {
        m_AnimatorController.SetBool("MovingDown", true);
    }

    void OnMoveLeft()
    {
        m_AnimatorController.SetBool("MovingLeft", true);
    }

    void OnMoveRight()
    {
        m_AnimatorController.SetBool("MovingRight", true);
    }

    void OnMoveUpDone()
    {
        m_AnimatorController.SetBool("MovingUp", false);
    }

    void OnMoveDownDone()
    {
        m_AnimatorController.SetBool("MovingDown", false);
    }

    void OnMoveLeftDone()
    {
        m_AnimatorController.SetBool("MovingLeft", false);
    }

    void OnMoveRightDone()
    {
        m_AnimatorController.SetBool("MovingRight", false);
    }

}
