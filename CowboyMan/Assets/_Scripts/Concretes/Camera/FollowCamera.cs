using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject watchGameObject;
    [Range(-15, 15)]
    [SerializeField] float xDistance, yDistance;
    [Range(-10, 10)]
    [SerializeField] float zDistance;
    [Range(-180, 180)]
    [SerializeField] float xRotate, yRotate, zRotate;
    void Start()
    {
        watchGameObject = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }
    void LateUpdate()
    {
        float x = watchGameObject.transform.position.x;
        float y = watchGameObject.transform.position.y;
        float z = watchGameObject.transform.position.z;
        transform.rotation = Quaternion.Euler(xRotate, yRotate, zRotate);
        transform.position = new Vector3(x + xDistance, y + yDistance, z + zDistance);
    }
}

