using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {

    [Header ("Basic Stats")]
    public int hp;
    public int movSpeed;
    public int fireRate;
    public int walkDir;
    public int shootDir;

    [Header ("Player Objects")]
    public Transform player;
    public Transform gunPoint;

    [Header ("State Booleans")]
    public bool isAlive;
    public bool isWalking;
    public bool isShooting;
    public bool canChangeState;
    public bool lastActionShoot;

    [Header ("State Machine")]
    public StateMachine state;
    public StateMachine newState;
    public enum StateMachine {
        IDLE_UP,
        IDLE_LEFT,
        IDLE_RIGHT,
        IDLE_DOWN,

        WALKING_UP,
        WALKING_LEFT,
        WALKING_RIGHT,
        WALKING_DOWN,

        SHOOTING_UP,
        SHOOTING_LEFT,
        SHOOTING_RIGHT,
        SHOOTING_DOWN,

        SHOOTING_UP_WALKING_DOWN,
        SHOOTING_UP_WALKING_LEFTRIGHT,

        SHOOTING_DOWN_WALKING_UP,
        SHOOTING_DOWN_WALKING_LEFTRIGHT,

        SHOOTING_LEFT_WALKING_RIGHT,
        SHOOTING_LEFT_WALKING_UPDOWN,

        SHOOTING_RIGHT_WALKING_LEFT,
        SHOOTING_RIGHT_WALKING_UPDOWN,

        #region  Just in case?
        // WALKING_UP_SHOOTING_LEFT,
        // WALKING_UP_SHOOTING_RIGHT,
        // WALKING_UP_SHOOTING_DOWN,

        // WALKING_LEFT_SHOOTING_UP,
        // WALKING_LEFT_SHOOTING_RIGHT,
        // WALKING_LEFT_SHOOTING_DOWN,

        // WALKING_RIGHT_SHOOTING_UP,
        // WALKING_RIGHT_SHOOTING_LEFT,
        // WALKING_RIGHT_SHOOTING_DOWN,

        // WALKING_DOWN_SHOOTING_UP,
        // WALKING_DOWN_SHOOTING_LEFT,
        // WALKING_DOWN_SHOOTING_RIGHT
        #endregion
    }

    public void StateManager (StateMachine nextState) {
        Debug.Log ("State changed: " + state + " to " + nextState);
        state = canChangeState ? nextState : state;
    }

    private void Start () {
        // newState = StateMachine.IDLE_UP;
        // state = StateMachine.IDLE_UP;
        canChangeState = true;
        player = GetComponent<Transform> ();
        walkDir = 2;
        shootDir = 2;
    }
}