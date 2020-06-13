using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject mainTarget;
    private GameObject _currentTarget;
    private bool _isMove = true;

    void Start()
    {
        _currentTarget = mainTarget;
    }

    void Update()
    {
        if (_currentTarget == null) _currentTarget = mainTarget;
        if (_isMove) {
            Move(_currentTarget); 
        } 
    }

    void Move(GameObject currentTarget)
    {

        float angle = Vector3.Angle(currentTarget.transform.position - transform.position, Vector3.up);

        Vector3 vectorToTarget = currentTarget.transform.position - transform.position;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.FromToRotation(Vector3.up, vectorToTarget), 60*Time.deltaTime);
        
        
        Vector3 direction = currentTarget.transform.position - transform.position;
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void SetTarget(GameObject target)
    {
        if (target.CompareTag("Ally") || target.CompareTag("Repairable"))
        {
            _currentTarget = target;
        }
    }

    public void SetMove(bool value)
    {
        _isMove = value;
    }
}
