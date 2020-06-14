using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class FindNewPosition : MonoBehaviour
{
    public WorkerMovement movement;
    
    public Vector3 _worldPos;
    public Camera camera;
    


    void Start()
    {
        movement = this.GetComponent<WorkerMovement>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonUp(1) && movement.IsSelect)
        {
            
            // _worldPos = Input.mousePosition;
            // float screenToCameraDistance = camera.nearClipPlane;
            // Vector3 mousePosNearClipPlane = new Vector3(_worldPos.x, _worldPos.y, screenToCameraDistance);
            // Vector3 worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = camera.nearClipPlane;
            _worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            movement.SetPosition(_worldPos);
            Debug.Log("Position is set!");
        }
    }
}