using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackTower : MonoBehaviour
{
    public float radius;
    public int damage;
    public float attackDelay;
    public Laser laser;
    HashSet<GameObject> objectsInScope;
    bool isInFight;
    GameObject currentTarget;
    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
        currentTarget = null;
        isInFight = false;
        objectsInScope = new HashSet<GameObject>();
        StartCoroutine("Attack");
    }

    // This method will decrease the object's health.
    /*private void AttackObject(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from enemy
    }*/

    IEnumerator Attack()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackDelay);
            Debug.Log(objectsInScope.Count);
            if (currentTarget != null)
            {
                laser.DirectLaser(transform.position, currentTarget.transform.position);
                currentTarget.GetComponent<Health>().DecreaseHealth(damage);
            }
            else
            {
                laser.DisableLaser();
                float minDist = float.MaxValue;
                GameObject nearestObject = null;
                foreach (var i in objectsInScope)
                {
                    if (i != null && Vector2.Distance(transform.position,i.transform.position) <= radius)
                    {
                        if (Vector2.Distance(transform.position, i.transform.position) <= minDist)
                        {
                            minDist = Vector2.Distance(transform.position, i.transform.position);
                            nearestObject = i;
                        }
                    }
                }
                if (nearestObject != null)
                    currentTarget = nearestObject;
            }
            
        }
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //AttackObject(other.gameObject);
            Debug.Log("Enemy spotted");
            objectsInScope.Add(other.gameObject);
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            AttackObject(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            laser.DisableLaser();
        }
    }*/
}