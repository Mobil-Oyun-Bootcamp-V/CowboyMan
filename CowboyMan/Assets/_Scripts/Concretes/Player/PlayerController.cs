using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: Header("MoveValues")]
    [field:SerializeField] public float horizontalSpeed { get; private set; }
    [field:SerializeField] public float verticalSpeed { get; set; }

    [Header("Boundaries")]
    [SerializeField][Range(-4f,-4.5f)]
    float boundaryMinX;
    [SerializeField][Range(4f,4.5f)] 
    float boundaryMaxX;

    Vector3 firstPosition;
    Mover _mover;
    FloatingJoystick _floatingJoystick;
    void Awake()
    {
        firstPosition = transform.position;
        _mover = new Mover(this);
        _floatingJoystick = GameObject.FindObjectOfType<FloatingJoystick>();
    }
    //Hareket+Input
    void FixedUpdate()
    {
        _mover.Active(_floatingJoystick.Horizontal,horizontalSpeed, verticalSpeed, boundaryMinX, boundaryMaxX);
    }
    //Playerý ilk pozisyona getir
     public void ResetPlayer()
    {   
        transform.position = firstPosition;
    }

}

