using System;
using UnityEngine;

public class HealTower : MonoBehaviour
{
    public float radius;
    public float healHP;
    public Laser laser;
    
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    // This method will increase the object's health.
    private void HealObject(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from ally
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ally")
        {
            HealObject(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ally")
        {
            HealObject(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ally")
        {
            laser.DisableLaser();
        }
    }
}