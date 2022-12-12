using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float lookAhead;
    [SerializeField] private CameraModel camModel;

    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        // camera theo nhan vat
        camModel.transform.position = new Vector3(camModel.player.position.x, camModel.transform.position.y, camModel.transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (camModel.aheadDistance * camModel.player.localScale.x), Time.deltaTime * camModel.cameraSpeed);

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        print("Welcom to new map");
        camModel.currentPosX = _newRoom.position.x;
    }
}
