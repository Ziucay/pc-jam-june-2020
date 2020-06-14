using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorkerMovement))]
public class ClickOnWorker : MonoBehaviour
{
    public WorkerMovement movement; 
    private void OnMouseDown()
    {
        Debug.Log("Click");
        movement.Select();
    }
}
