using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
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
    void FixedUpdate()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0) * speed;
        mouseMove = new Vector3(0, 0, 0);
        position = Input.mousePosition;
        if (position.x <= Screen.width * widthTrigger)
        {
            mouseMove.x = -1;
            Debug.Log("1");
        }
        else if (position.x >= Screen.width * (1 - widthTrigger))
        {
            mouseMove.x = 1;
            Debug.Log("2");
        }
            
        if (position.y <= Screen.height * heightTrigger)
        {
            mouseMove.y = -1;
            Debug.Log(3);
        }
        else if (position.y >= Screen.height * (1 - heightTrigger))
        {
            mouseMove.y = 1;
            Debug.Log(4);
        }
            
        mouseMove = mouseMove * speed;
        transform.position = transform.position + move + mouseMove;
    }
}
