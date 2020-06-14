using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickToggle : MonoBehaviour
{
    public PlayerClick pk;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pk.enabled)
                pk.enabled = false;
            else
                pk.enabled = true;
        }
    }
}
