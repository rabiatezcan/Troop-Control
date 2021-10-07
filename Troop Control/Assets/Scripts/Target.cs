using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float Y_AXIS_POSITION = -.46f;
    
    public void UpdatePosition(Vector3 position)
    {
        transform.position = new Vector3(position.x, Y_AXIS_POSITION, position.z);
    }
    
 
    
}
