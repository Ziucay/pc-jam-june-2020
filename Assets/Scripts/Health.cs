using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Health : MonoBehaviour
{
    public delegate void HealthHandler();
    public event HealthHandler OnHpIncreased, OnHpDecreased, OnDeath;
    public int health;
    public int maxHealth;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DecreaseHealth(int hp)
    {
        health = Mathf.Max(0, health - hp);
        OnHpDecreased.Invoke();
        if (hp == 0)
            Death();
    }

    public void IncreaseHealth(int hp)
    {
        health = Mathf.Min(maxHealth, health + hp);
        OnHpIncreased.Invoke();
    }

    void Death()
    {
        OnDeath.Invoke();
    }

}
