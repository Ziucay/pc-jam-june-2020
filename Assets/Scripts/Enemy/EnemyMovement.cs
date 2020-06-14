using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject mainTarget;
    private GameObject _currentTarget;
    private Health healtScript;
    private bool _isMove = true;

    void Start()
    {
        if (mainTarget == null)
        {
            mainTarget = GameObject.Find("MainTarget");
        }
        _currentTarget = mainTarget;
        healtScript = GetComponent<Health>();
        healtScript.OnDeath += Death;
    }

    void Death()
    {
        Destroy(this.gameObject);
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
        if (currentTarget == null)
            return;
        float angle = Vector3.Angle(currentTarget.transform.position - transform.position, Vector3.up);

        Vector3 vectorToTarget = currentTarget.transform.position - transform.position;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.FromToRotation(Vector3.up, vectorToTarget), 60*Time.deltaTime);
        
        
        Vector3 direction = currentTarget.transform.position - transform.position;
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void SetTarget(GameObject target)
    {
        if (target.CompareTag("Ally") || target.CompareTag("Repairable") || target.CompareTag("Wall") || target.CompareTag("Tower"))
        {
            _currentTarget = target;
        }
    }

    public void SetMove(bool value)
    {
        _isMove = value;
    }
}
