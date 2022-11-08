  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public float SmoothSpeed = 0.125f;
    public Transform playerTransform;
    public Vector3 offset;
    public bool isLookAt = true;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void LateUpdate(){
        // Vector3 desiredPosition = new Vector3(0, playerTransform.position.y + offset.y, playerTransform.position.z + offset.z);
        // transform.LookAt(playerTransform);
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;
        if(!isLookAt)return;
        transform.LookAt(playerTransform);
    }
}
