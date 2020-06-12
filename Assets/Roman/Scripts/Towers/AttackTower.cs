using UnityEngine;

public class AttackTower : MonoBehaviour
{
    public float radius;
    public float hp;
    public float maxHP;
    public float attackPoints;
    public float healHP;
    public float slowMovement;
    
    public HealthBar healthBar;
    public Laser laser;

    void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = radius;
    }

    void Update()
    {
        if (this.hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar.UpdateHealthBar(hp);
        }
    }
    
    // Call this method when someone heals the tower
    public void increaseHP(float hp)
    {
        // todo complete the system of interactions between enemies and towers
        this.hp += hp;
        this.hp = Mathf.Min(maxHP, this.hp);
    }

    // Call this method when the enemy attack the tower
    public void decreaseHP(float hp)
    {
        this.hp -= hp;
    }

    // This method will decrease the object's health.
    private void AttackObject(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from enemy
    }

    // This method will decrease the speed of movement
    private void SlowMovement(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from enemy
    }

    // This method will increase the object's health.
    private void HealObject(GameObject gameObject)
    {
        laser.DirectLaser(transform.position, gameObject.transform.position);
        // todo call the appropriate method from ally
    }

    private void StopAttack()
    {
        laser.DisableLaser();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            AttackObject(other.gameObject);
            SlowMovement(other.gameObject);
        }

        if (other.tag == "Ally")
        {
            HealObject(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            AttackObject(other.gameObject);
            SlowMovement(other.gameObject);
        }
        if (other.tag == "Ally")
        {
            HealObject(other.gameObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            StopAttack();
        }
    }
}