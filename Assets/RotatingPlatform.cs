﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 axis;
    void Update(){
        transform.Rotate(axis);
    }
}
