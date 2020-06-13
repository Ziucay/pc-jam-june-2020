using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyMovement))]
public class OverlapObjects : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private EnemyMovement movement;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);
        CheckColliders(colliders);
    }

    private void CheckColliders(Collider2D[] colliders)
    {
        List<Collider2D> sortedColliders = new List<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Ally") || colliders[i].CompareTag("Repairable"))
            {
                sortedColliders.Add(colliders[i]);
            } 
        }

        float minDistanсe = float.MaxValue;
        Collider2D nearestCollider = new Collider2D();
        foreach (var VARIABLE in sortedColliders)
        {
            float distance = (transform.position - VARIABLE.transform.position).sqrMagnitude;
            if (distance < minDistanсe) nearestCollider = VARIABLE;

        }
        
        if (nearestCollider != null) movement.SetTarget(nearestCollider.gameObject);
    }
}
