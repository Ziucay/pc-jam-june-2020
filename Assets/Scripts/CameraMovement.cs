using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool EnableRTSMove;
    //then we move camera by mouse(percentage)
    [Range(0, 0.5f)]
    public float heightTrigger;
    [Range(0, 0.5f)]
    public float widthTrigger;
    Vector3 mouseMove;
    Vector3 position;
    Vector3 move;
    [SerializeField]
    private float speed;
    [SerializeField,Range(0,3)]
    private float zoomSpeed;
    [SerializeField]
    private int ZoomBoundLeft;
    [SerializeField]
    private int ZoomBoundRight;
    private string zoom = "Mouse ScrollWheel";
    Camera camera;
    
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        //TODO: Camera zoom
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0) * speed;
        mouseMove = new Vector3(0, 0, 0);
        position = Input.mousePosition;
        if (position.x <= Screen.width * widthTrigger)
        {
            mouseMove.x = -1;
        }
        else if (position.x >= Screen.width * (1 - widthTrigger))
        {
            mouseMove.x = 1;
        }
            
        if (position.y <= Screen.height * heightTrigger)
        {
            mouseMove.y = -1;
        }
        else if (position.y >= Screen.height * (1 - heightTrigger))
        {
            mouseMove.y = 1;
        }
        if ((camera.orthographicSize + Input.GetAxisRaw(zoom) * zoomSpeed) >= ZoomBoundLeft && (camera.orthographicSize + Input.GetAxisRaw(zoom) * zoomSpeed) <= ZoomBoundRight)
        camera.orthographicSize += Input.GetAxisRaw(zoom) * zoomSpeed;
        if (EnableRTSMove)
            mouseMove = mouseMove * speed;
        else
            mouseMove = Vector3.zero;
        transform.position = transform.position + move + mouseMove;
    }
}
