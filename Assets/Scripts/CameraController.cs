using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField, Range (0.01f, 1.0f)] float cameraSpeed;
    [SerializeField, Range (1, 20)] float offsetDistance;
    GameObject player;
    PlayerAttributes pa;
    PlayerController controller;

    private void Start () {
        player = GameObject.Find ("Player");
        pa = player.GetComponent<PlayerAttributes> ();
        controller = player.GetComponent<PlayerController> ();
    }

    private void FixedUpdate () {
        MoveCamera (player.transform);
    }

    void MoveCamera (Transform target) {

        Vector3 smoothFollow = Vector3.Lerp (transform.position, target.position, cameraSpeed);

        // Offset distance to increase frontside view ?
        // TODO Need some minor fixes
        // if (pa.lastActionShoot) {
        //     switch (pa.shootDir) {
        //         case 1:
        //             smoothFollow.y += offsetDistance;
        //             break;
        //         case 2:
        //             smoothFollow.y -= offsetDistance;
        //             break;
        //         case 3:
        //             smoothFollow.x -= offsetDistance;
        //             break;
        //         case 4:
        //             smoothFollow.x += offsetDistance;
        //             break;
        //     }
        // } else {
        //     switch (pa.walkDir) {
        //         case 1:
        //             smoothFollow.y += offsetDistance;
        //             break;
        //         case 2:
        //             smoothFollow.y -= offsetDistance;
        //             break;
        //         case 3:
        //             smoothFollow.x -= offsetDistance;
        //             break;
        //         case 4:
        //             smoothFollow.x += offsetDistance;
        //             break;
        //     }
        // }

        smoothFollow.z = -10;
        transform.position = smoothFollow;
    }

}