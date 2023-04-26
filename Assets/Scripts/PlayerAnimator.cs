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

    void Start () {
        controller = GetComponent<PlayerController> ();
        animator = GetComponent<Animator> ();
        pa = GetComponent<PlayerAttributes> ();
        state = STATE.IDLEDOWN;
    }
    void Update () {
        // Animate ();
        // CheckState ();
        // UpdateState ();

        StateConditions ();
        SetUpDirections ();
        ChangeAnimationToState ();
    }

    #region Yuri code

    void ChangeAnimationToState () {
        Debug.Log ("new State: " + pa.newState);
        Debug.Log ("State: " + pa.state);
        switch (pa.state) {
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
            case PlayerAttributes.StateMachine.SHOOTING_UP:
                animator.Play ("Idle_Up");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_DOWN:
                animator.Play ("Idle_Down");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_LEFT:
                animator.Play ("Idle_Left");
                break;
            case PlayerAttributes.StateMachine.SHOOTING_RIGHT:
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
        }
    }

    void StateConditions () {
        // Walking-Shooting Conditions
        if (pa.isWalking && pa.isShooting) {
            Debug.Log ("walking n shooting");
            if (pa.shootDir == pa.walkDir) {
                pa.newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.WALKING_UP :
                    pa.walkDir == 2 ? PlayerAttributes.StateMachine.WALKING_DOWN :
                    pa.walkDir == 3 ? PlayerAttributes.StateMachine.WALKING_LEFT :
                    PlayerAttributes.StateMachine.WALKING_RIGHT;
            } else {
                if (pa.shootDir == 1) {
                    pa.newState = pa.walkDir == 2 ? PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_DOWN :
                        pa.walkDir == 3 || pa.walkDir == 4 ? PlayerAttributes.StateMachine.SHOOTING_UP_WALKING_LEFTRIGHT :
                        pa.state;
                }
                if (pa.shootDir == 2) {
                    pa.newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_UP :
                        pa.walkDir == 3 || pa.walkDir == 4 ? PlayerAttributes.StateMachine.SHOOTING_DOWN_WALKING_LEFTRIGHT :
                        pa.state;
                }
                if (pa.shootDir == 3) {
                    pa.newState = pa.walkDir == 4 ? PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_RIGHT :
                        pa.walkDir == 1 || pa.walkDir == 2 ? PlayerAttributes.StateMachine.SHOOTING_LEFT_WALKING_UPDOWN :
                        pa.state;
                }
                if (pa.shootDir == 4) {
                    pa.newState = pa.walkDir == 4 ? PlayerAttributes.StateMachine.WALKING_RIGHT :
                        pa.walkDir == 3 ? PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_LEFT :
                        pa.walkDir == 1 || pa.walkDir == 2 ? PlayerAttributes.StateMachine.SHOOTING_RIGHT_WALKING_UPDOWN :
                        pa.state;
                }
            }
        }
        // Walking Conditions
        else if (pa.isWalking) {
            Debug.Log ("walking");
            pa.newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.WALKING_UP :
                pa.walkDir == 2 ? PlayerAttributes.StateMachine.WALKING_DOWN :
                pa.walkDir == 3 ? PlayerAttributes.StateMachine.WALKING_LEFT :
                pa.walkDir == 4 ? PlayerAttributes.StateMachine.WALKING_RIGHT : pa.state;
        }
        // Idle-Shooting Conditions
        else if (pa.isShooting) {
            Debug.Log ("shooting");
            pa.newState = pa.shootDir == 1 ? PlayerAttributes.StateMachine.SHOOTING_UP :
                pa.shootDir == 2 ? PlayerAttributes.StateMachine.SHOOTING_DOWN :
                pa.shootDir == 3 ? PlayerAttributes.StateMachine.SHOOTING_LEFT :
                pa.shootDir == 4 ? PlayerAttributes.StateMachine.SHOOTING_RIGHT : pa.state;
            pa.walkDir = pa.shootDir;
        }
        // Idle Conditions
        // (!pa.isWalking && !pa.isShooting)
        else {
            Debug.Log ("idle");
            pa.newState = pa.walkDir == 1 ? PlayerAttributes.StateMachine.IDLE_UP :
                pa.walkDir == 2 ? PlayerAttributes.StateMachine.IDLE_DOWN :
                pa.walkDir == 3 ? PlayerAttributes.StateMachine.IDLE_LEFT :
                pa.walkDir == 4 ? PlayerAttributes.StateMachine.IDLE_RIGHT : pa.state;
        }
        // Change the State
        if (!pa.state.Equals (pa.newState)) pa.StateManager (pa.newState);
    }

    void SetUpDirections () {

        pa.isWalking = (controller.horizontal != 0 || controller.vertical != 0);
        pa.isShooting = (controller.shootHorizontal != 0 || controller.shootVertical != 0);

        if (pa.isWalking) {
            pa.walkDir = controller.vertical > 0 ? 1 : controller.vertical < 0 ? 2 :
                controller.horizontal<0 ? 3 : controller.horizontal> 0 ? 4 : pa.walkDir;
            pa.lastActionShoot = false;
            // if (controller.vertical > 0) pa.walkDir = 1;
            // if (controller.vertical < 0) pa.walkDir = 2;
            // if (controller.horizontal < 0) pa.walkDir = 3;
            // if (controller.horizontal > 0) pa.walkDir = 4;
        }
        if (pa.isShooting) {
            pa.shootDir = controller.shootVertical > 0 ? 1 : controller.shootVertical < 0 ? 2 :
                controller.shootHorizontal<0 ? 3 : controller.shootHorizontal> 0 ? 4 : pa.shootDir;
            pa.lastActionShoot = true;
            // if (controller.shootVertical > 0) pa.shootDir = 1;
            // if (controller.shootVertical < 0) pa.shootDir = 2;
            // if (controller.shootHorizontal < 0) pa.shootDir = 3;
            // if (controller.shootHorizontal > 0) pa.shootDir = 4;
        }
        //TODO Remove this once lookDir logic is done
        //pa.walkDir = pa.lastActionShoot ? pa.shootDir : pa.walkDir;

    }

    #endregion
    // #################################################################################################################
    #region Renatin code
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