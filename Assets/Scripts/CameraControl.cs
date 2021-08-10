using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float distance=3;
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y+ distance, -10);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
    }
}
