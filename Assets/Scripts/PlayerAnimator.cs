using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Vector2 movement;
    STATE state;
    Animator animator;
    PlayerController controller;
    bool isWalking, isShooting;
    int dir;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        state = STATE.IDLEDOWN;
    }
    enum STATE
    {
        WALKINGUP,
        WALKINGDOWN,
        WALKINGLEFT,
        WALKINGRIGHT,

        IDLEUP,
        IDLEDOWN,
        IDLELEFT,
        IDLERIGHT,
    }

    void Update()
    {
        Animate();
        CheckState();
        UpdateState();
    }

    void Animate()
    {
        switch (this.state)
        {
            case STATE.WALKINGUP:
                animator.Play("Walking_Up");
                break;

            case STATE.WALKINGDOWN:
                animator.Play("Walking_Down");
                break;

            case STATE.WALKINGLEFT:
                animator.Play("Walking_Left");
                break;

            case STATE.WALKINGRIGHT:
                animator.Play("Walking_Right");
                break;

            case STATE.IDLEUP:
                animator.Play("Idle_Up");
                break;

            case STATE.IDLEDOWN:
                animator.Play("Idle_Down");
                break;

            case STATE.IDLELEFT:
                animator.Play("Idle_Left");
                break;

            case STATE.IDLERIGHT:
                animator.Play("Idle_Right");
                break;
        }
    }

    void UpdateState()
    {
        if (!isWalking && !isShooting)
        {
            if (dir == 1) state = STATE.IDLEUP;
            if (dir == 2) state = STATE.IDLEDOWN;
            if (dir == 3) state = STATE.IDLELEFT;
            if (dir == 4) state = STATE.IDLERIGHT;
        }

        if (isShooting && !isWalking)
        {
            if (dir == 1) state = STATE.IDLEUP;
            if (dir == 2) state = STATE.IDLEDOWN;
            if (dir == 3) state = STATE.IDLELEFT;
            if (dir == 4) state = STATE.IDLERIGHT;
        }

        if (isShooting && isWalking)
        {
            if (dir == 1) state = STATE.WALKINGUP;
            if (dir == 2) state = STATE.WALKINGDOWN;
            if (dir == 3) state = STATE.WALKINGLEFT;
            if (dir == 4) state = STATE.WALKINGRIGHT;
        }

        if (isWalking && !isShooting)
        {
            if (dir == 1) state = STATE.WALKINGUP;
            if (dir == 2) state = STATE.WALKINGDOWN;
            if (dir == 3) state = STATE.WALKINGLEFT;
            if (dir == 4) state = STATE.WALKINGRIGHT;
        }
    }

    void CheckState()
    {
        if (controller.horizontal != 0 || controller.vertical != 0) isWalking = true;
        else isWalking = false;
        if (controller.shootHorizontal != 0 || controller.shootVertical != 0) isShooting = true;
        else isShooting = false;

        if (isShooting)
        {
            if (controller.shootVertical > 0) dir = 1;
            if (controller.shootVertical < 0) dir = 2;
            if (controller.shootHorizontal > 0) dir = 4;
            if (controller.shootHorizontal < 0) dir = 3;
        }
        else if (isWalking)
        {
            if (controller.vertical > 0) dir = 1;
            if (controller.vertical < 0) dir = 2;
            if (controller.horizontal > 0) dir = 4;
            if (controller.horizontal < 0) dir = 3;
        }
    }
}

