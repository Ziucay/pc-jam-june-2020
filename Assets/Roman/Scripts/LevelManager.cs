using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private TowerManager towerManager;

    // Start is called before the first frame update
    void Start()
    {
        towerManager = FindObjectOfType<TowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 towerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPosition.z = 0;
            towerManager.AddAttackTower(towerPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 towerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPosition.z = 0;
            towerManager.AddHealTower(towerPosition);
        }

        if (Input.GetMouseButtonDown(2))
        {
            Vector3 towerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPosition.z = 0;
            towerManager.AddSlowerTower(towerPosition);
        }
    }
}