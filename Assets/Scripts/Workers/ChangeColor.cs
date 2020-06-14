using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private WorkerMovement movement;
    void Start()
    {
        render = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.IsSelect)
        {
            render.color = Color.white;
        }
        else
        {
            render.color = Color.red;
        }
    }
}
