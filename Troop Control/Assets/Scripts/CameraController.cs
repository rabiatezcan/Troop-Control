using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : ControllerBase
{
    private float _movementRate;
    
    public override void Initialize()
    {
        _movementRate = 10f * Time.deltaTime;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.Mouse2))
            {
                transform.Rotate(new Vector3(-1, 0, 0), _movementRate);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z +_movementRate);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.Mouse2))
            {
                transform.Rotate(new Vector3(0, 1, 0), _movementRate);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - _movementRate, transform.position.y, transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Mouse2))
            {
                transform.Rotate(new Vector3(1, 0, 0), _movementRate);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _movementRate);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.Mouse2))
            {
                transform.Rotate(new Vector3(0, -1, 0), _movementRate);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + _movementRate, transform.position.y, transform.position.z);
            }
        }
    }

  
}
