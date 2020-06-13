using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
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
        Destroy(ally);
        //Need HP system
    }
}
