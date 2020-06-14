using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    public bool _isSelect = false;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector3 _newPosition;
    private float _error;
    public Vector3 direction;

    private void Start()
    {
        _newPosition = transform.position;
    }

    void Update()
    {
        if (IsSelect)
        {
            Move();
        }
    }

    public bool IsSelect => _isSelect;

    public void Select()
    {
        _isSelect = true;
    }

    public void Deselect()
    {
        _isSelect = false;
    }

    private void Move()
    {
        direction = _newPosition - transform.position;
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _newPosition) < 0.1 && IsSelect
                                                                     && _newPosition != transform.position)
        {
            _newPosition = transform.position;
            Deselect();
        }
    }

    public void SetPosition(Vector3 position)
    {
        _newPosition = position;
        _newPosition.z = 0;
    }
}
