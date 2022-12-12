using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;
    public float currentPosX;
    [SerializeField] public Transform player;
    [SerializeField] public float aheadDistance;
    [SerializeField] public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
