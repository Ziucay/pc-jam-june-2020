using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    private Health hScript;
    void Start()
    {
        hScript = GetComponent<Health>();
        hScript.OnDeath += GameOver;
    }

    void Update()
    {
        
    }

    void GameOver()
    {
        Destroy(this.gameObject);
    }
}
