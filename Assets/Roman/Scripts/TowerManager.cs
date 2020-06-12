using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    // List of variables of different types of towers
    public GameObject attackTower;
    public GameObject healTower;

    // List of methods to create a new tower of current type
    public void AddAttackTower(Vector3 towerPosition)
    {
        attackTower.transform.position = towerPosition;
        Instantiate(attackTower);
    }
    public void AddHealTower(Vector3 towerPosition)
    {
        healTower.transform.position = towerPosition;
        Instantiate(healTower);
    }
}