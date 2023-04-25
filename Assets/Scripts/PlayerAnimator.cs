using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    PlayerAttributes pa;
    Vector2 movement;
    STATE state;
    Animator animator;
    PlayerController controller;
    bool isWalking, isShooting;
    int dir;

    #region Yuri code
    void UpdateAnimationIF () {
        if (pa.State == PlayerAttributes.StateMachine.WALKING_UP) animator.Play ("Walking_Up");
        else if (pa.State == PlayerAttributes.StateMachine.WALKING_DOWN) animator.Play ("Walking_Down");
        else if (pa.State == PlayerAttributes.StateMachine.WALKING_LEFT) animator.Play ("Walking_Left");
        else if (pa.State == PlayerAttributes.StateMachine.WALKING_RIGHT) animator.Play ("Walking_Right");

        else if (pa.State == PlayerAttributes.StateMachine.IDLE_UP) animator.Play ("Idle_Up");
        else if (pa.State == PlayerAttributes.StateMachine.IDLE_DOWN) animator.Play ("Idle_Down");
        else if (pa.State == PlayerAttributes.StateMachine.IDLE_LEFT) animator.Play ("Idle_Left");
        else if (pa.State == PlayerAttributes.StateMachine.IDLE_RIGHT) animator.Play ("Idle_Right");

        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_DOWN) animator.Play ("Walking_Up");
        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_LEFTRIGHT) animator.Play ("Walking_Up");

        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_UP) animator.Play ("Walking_Down");
        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_LEFTRIGHT) animator.Play ("Walking_Down");

        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_RIGHT) animator.Play ("Walking_Left");
        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_UPDOWN) animator.Play ("Walking_Left");

        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_LEFT) animator.Play ("Walking_Right");
        else if (pa.State == PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_UPDOWN) animator.Play ("Walking_Right");

        #region Just in case?
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_UP_SHOOTING_LEFT) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_UP_SHOOTING_RIGHT) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_UP_SHOOTING_DOWN) animator.Play ("");

        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_LEFT_SHOOTING_UP) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_LEFT_SHOOTING_RIGHT) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_LEFT_SHOOTING_DOWN) animator.Play ("");

        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_RIGHT_SHOOTING_UP) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_RIGHT_SHOOTING_LEFT) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_RIGHT_SHOOTING_DOWN) animator.Play ("");

        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_DOWN_SHOOTING_UP) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_DOWN_SHOOTING_LEFT) animator.Play ("");
        // else if (pa.PlayerState == PlayerAttributes.PlayerStateMachine.WALKING_DOWN_SHOOTING_RIGHT) animator.Play ("");
        #endregion
    }

    void UpdateAnimationByPlayerState () {
        switch (pa.State) {
            case PlayerAttributes.StateMachine.WALKING_UP:
                animator.Play ("Walking_Up");
                break;
            case PlayerAttributes.StateMachine.WALKING_DOWN:
                animator.Play ("Walking_Down");
                break;
            case PlayerAttributes.StateMachine.WALKING_LEFT:
                animator.Play ("Walking_Left");
                break;
            case PlayerAttributes.StateMachine.WALKING_RIGHT:
                animator.Play ("Walking_Right");
                break;
            case PlayerAttributes.StateMachine.IDLE_UP:
                animator.Play ("Idle_Up");
                break;
            case PlayerAttributes.StateMachine.IDLE_DOWN:
                animator.Play ("Idle_Down");
                break;
            case PlayerAttributes.StateMachine.IDLE_LEFT:
                animator.Play ("Idle_Left");
                break;
            case PlayerAttributes.StateMachine.IDLE_RIGHT:
                animator.Play ("Idle_Right");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_DOWN:
                animator.Play ("Walking_Up");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_LEFTRIGHT:
                animator.Play ("Walking_Up");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_UP:
                animator.Play ("Walking_Down");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_LEFTRIGHT:
                animator.Play ("Walking_Down");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_RIGHT:
                animator.Play ("Walking_Left");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_UPDOWN:
                animator.Play ("Walking_Left");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_LEFT:
                animator.Play ("Walking_Right");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_UPDOWN:
                animator.Play ("Walking_Right");
                break;
            default:
                break;
        }
    }

    void StateConditions () {
        //TODO Change to Switch statement?
        PlayerAttributes.StateMachine newState = pa.State;
        // Idle Conditions
        if (!pa.isWalking && !pa.isShooting) {
            newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.IDLE_UP : pa.State;
            newState = pa.walkDir == 2 ? PlayerAttributes.StateMachine.IDLE_DOWN : pa.State;
            newState = pa.walkDir == 3 ? PlayerAttributes.StateMachine.IDLE_LEFT : pa.State;
            newState = pa.walkDir == 4 ? PlayerAttributes.StateMachine.IDLE_RIGHT : pa.State;
        }

        // Idle-Shooting Conditions
        if (!isWalking && isShooting) {
            newState = pa.shootDir == 1 ? PlayerAttributes.StateMachine.SHOOTING_UP : pa.State;
            newState = pa.shootDir == 2 ? PlayerAttributes.StateMachine.SHOOTING_LEFT : pa.State;
            newState = pa.shootDir == 3 ? PlayerAttributes.StateMachine.SHOOTING_LEFT : pa.State;
            newState = pa.shootDir == 4 ? PlayerAttributes.StateMachine.SHOOTING_RIGHT : pa.State;
        }

        // Walking Conditions
        if (isWalking && !isShooting) {
            newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.WALKING_UP : pa.State;
            newState = pa.walkDir == 2 ? PlayerAttributes.StateMachine.WALKING_DOWN : pa.State;
            newState = pa.walkDir == 3 ? PlayerAttributes.StateMachine.WALKING_LEFT : pa.State;
            newState = pa.walkDir == 4 ? PlayerAttributes.StateMachine.WALKING_RIGHT : pa.State;
        }

        // Walking-Shooting Conditions
        if (isWalking && isShooting) {
            newState = pa.shootDir == 1 && pa.walkDir == 1 ?
                PlayerAttributes.StateMachine.WALKING_UP : pa.State;
            newState = pa.shootDir == 1 && pa.walkDir == 2 ?
                PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_DOWN : pa.State;
            newState = pa.shootDir == 1 && (pa.walkDir == 3 || pa.walkDir == 4) ?
                PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_LEFTRIGHT : pa.State;

            newState = pa.shootDir == 2 && pa.walkDir == 2 ?
                PlayerAttributes.StateMachine.WALKING_DOWN : pa.State;
            newState = pa.shootDir == 2 && pa.walkDir == 1 ?
                PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_UP : pa.State;
            newState = pa.shootDir == 2 && (pa.walkDir == 3 || pa.walkDir == 4) ?
                PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_LEFTRIGHT : pa.State;

            newState = pa.shootDir == 3 && pa.walkDir == 3 ?
                PlayerAttributes.StateMachine.WALKING_LEFT : pa.State;
            newState = pa.shootDir == 3 && pa.walkDir == 4 ?
                PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_RIGHT : pa.State;
            newState = pa.shootDir == 3 && (pa.walkDir == 1 || pa.walkDir == 2) ?
                PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_UPDOWN : pa.State;

            newState = pa.shootDir == 4 && pa.walkDir == 4 ?
                PlayerAttributes.StateMachine.WALKING_RIGHT : pa.State;
            newState = pa.shootDir == 4 && pa.walkDir == 3 ?
                PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_LEFT : pa.State;
            newState = pa.shootDir == 4 && (pa.walkDir == 1 || pa.walkDir == 2) ?
                PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_UPDOWN : pa.State;

        }
        // Change the State
        pa.StateManager (newState);
    }
    #endregion
    // #################################################################################################################
    #region Renatin code
    void Start () {
        controller = GetComponent<PlayerController> ();
        animator = GetComponent<Animator> ();
        state = STATE.IDLEDOWN;
    }
    enum STATE {
        WALKINGUP,
        WALKINGDOWN,
        WALKINGLEFT,
        WALKINGRIGHT,

        IDLEUP,
        IDLEDOWN,
        IDLELEFT,
        IDLERIGHT,
    }

    void Update () {
        Animate ();
        CheckState ();
        UpdateState ();
    }

    void Animate () {
        switch (this.state) {
            case STATE.WALKINGUP:
                animator.Play ("Walking_Up");
                break;

            case STATE.WALKINGDOWN:
                animator.Play ("Walking_Down");
                break;

            case STATE.WALKINGLEFT:
                animator.Play ("Walking_Left");
                break;

            case STATE.WALKINGRIGHT:
                animator.Play ("Walking_Right");
                break;

            case STATE.IDLEUP:
                animator.Play ("Idle_Up");
                break;

            case STATE.IDLEDOWN:
                animator.Play ("Idle_Down");
                break;

            case STATE.IDLELEFT:
                animator.Play ("Idle_Left");
                break;

            case STATE.IDLERIGHT:
                animator.Play ("Idle_Right");
                break;
        }
    }

    void UpdateState () {
        if (!isWalking && !isShooting) {
            if (dir == 1) state = STATE.IDLEUP;
            if (dir == 2) state = STATE.IDLEDOWN;
            if (dir == 3) state = STATE.IDLELEFT;
            if (dir == 4) state = STATE.IDLERIGHT;
        }

        if (isShooting && !isWalking) {
            if (dir == 1) state = STATE.IDLEUP;
            if (dir == 2) state = STATE.IDLEDOWN;
            if (dir == 3) state = STATE.IDLELEFT;
            if (dir == 4) state = STATE.IDLERIGHT;
        }

        if (isShooting && isWalking) {
            if (dir == 1) state = STATE.WALKINGUP;
            if (dir == 2) state = STATE.WALKINGDOWN;
            if (dir == 3) state = STATE.WALKINGLEFT;
            if (dir == 4) state = STATE.WALKINGRIGHT;
        }

        if (isWalking && !isShooting) {
            if (dir == 1) state = STATE.WALKINGUP;
            if (dir == 2) state = STATE.WALKINGDOWN;
            if (dir == 3) state = STATE.WALKINGLEFT;
            if (dir == 4) state = STATE.WALKINGRIGHT;
        }
    }

    void CheckState () {
        if (controller.horizontal != 0 || controller.vertical != 0) isWalking = true;
        else isWalking = false;
        if (controller.shootHorizontal != 0 || controller.shootVertical != 0) isShooting = true;
        else isShooting = false;

        if (isShooting) {
            if (controller.shootVertical > 0) dir = 1;
            if (controller.shootVertical < 0) dir = 2;
            if (controller.shootHorizontal > 0) dir = 4;
            if (controller.shootHorizontal < 0) dir = 3;
        } else if (isWalking) {
            if (controller.vertical > 0) dir = 1;
            if (controller.vertical < 0) dir = 2;
            if (controller.horizontal > 0) dir = 4;
            if (controller.horizontal < 0) dir = 3;
        }
    }
    #endregion
}