using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerMovement : MonoBehaviour
{
    private bool _isSelect = false;
    [SerializeField] private float speed = 10f;
    private Vector3 _newPosition;
    private float _error;

    // Update is called once per frame
    void Update()
    {
        if (_isSelect)
        {
            Move();
        }
    }

    public bool IsSelect => _isSelect;

    public void Select(bool value)
    {
        _isSelect = value;
    }

    private void Move()
    {
        Vector3 direction = _newPosition - transform.position;
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (transform.position.x + _error <= _newPosition.x 
            && transform.position.y + _error <= _newPosition.x)
        {
            _isSelect = false;
        }
    }
}
