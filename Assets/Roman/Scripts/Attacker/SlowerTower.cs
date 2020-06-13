using UnityEngine;

public class SlowerTower : MonoBehaviour
{
    public float radius;
    public float slowMovement;
    public Laser laser;

    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    // This method will decrease the speed of movement
    private void SlowMovement(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from enemy
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SlowMovement(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SlowMovement(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            laser.DisableLaser();
        }
    }
}