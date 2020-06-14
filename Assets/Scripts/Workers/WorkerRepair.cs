using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerRepair : MonoBehaviour
{
    public float radius;
    public int speedOfRepair;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var VARIABLE in colliders) 
        {
            if (VARIABLE.CompareTag("Tower") || VARIABLE.CompareTag("Wall") || VARIABLE.CompareTag("Ally"))
            {
                Repair(VARIABLE.gameObject);
            }
        }
    }

    private void Repair(GameObject ally)
    {
        Debug.Log("Repair!");
        ally.GetComponent<Health>().IncreaseHealth(speedOfRepair);
    }
}
