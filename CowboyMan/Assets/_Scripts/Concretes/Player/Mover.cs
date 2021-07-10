using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover 
{
    PlayerController _playerController;
    Rigidbody rb;

    float horizontalSpeed;
    float verticalSpeed;

    public Mover(PlayerController playerController)
    {
        _playerController = playerController;
        rb = playerController.GetComponent<Rigidbody>();
    }
    public void Active(float horizontalValue,float x, float z,float boundaryMinX,float boundaryMaxX)
    {  

        horizontalSpeed = x * Time.deltaTime * horizontalValue;
        verticalSpeed = z * Time.deltaTime;

        //Sýnýrlama
        if (_playerController.transform.position.x <= boundaryMinX && horizontalValue <= 0)
        {
            horizontalSpeed = 0;
        }
        else if (_playerController.transform.position.x >= boundaryMaxX && horizontalValue >= 0)
        {
            horizontalSpeed = 0;
        }
        //Hareket
        rb.velocity = new Vector3(horizontalSpeed, rb.velocity.y, verticalSpeed);
    }
 }
    

