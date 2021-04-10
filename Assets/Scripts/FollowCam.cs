using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float yBias = 1.9f;

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + yBias, -10);
    }
}
