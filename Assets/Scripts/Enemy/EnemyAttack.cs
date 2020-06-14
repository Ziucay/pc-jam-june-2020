using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ally") || other.CompareTag("Repairable"))
        {
            GetComponent<EnemyMovement>().SetMove(false);
            Attack(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<EnemyMovement>().SetMove(true);
    }

    private void Attack(GameObject ally)
    {
        Debug.Log(ally.name);
        ally.GetComponent<Health>().DecreaseHealth(damage);
    }
}
