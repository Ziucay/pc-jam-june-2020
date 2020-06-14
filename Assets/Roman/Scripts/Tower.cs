using UnityEngine;

public class Tower : MonoBehaviour
{
    //public float currentHP;
    //public float maxHP;

    public HealthBar healthBar;
    public Health healthScript;

    void Start()
    {
        healthScript = transform.GetComponent<Health>();
        healthScript.OnHpIncreased += UpdateHealthBar;
        healthScript.OnHpDecreased += UpdateHealthBar;
        healthScript.OnDeath += DestroyTower;
    }

    void Update()
    {
        /*if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar.UpdateHealthBar(currentHP, maxHP);
        }*/
    }

    void DestroyTower()
    {
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar();
    }
    //Azat: thispart duplicates health
    /*
    // Call this method when someone heals the tower
    public void increaseHP(float hp)
    {
        // todo complete the system of interactions between enemies and towers
        currentHP = Mathf.Min(maxHP, currentHP + hp);
    }

    // Call this method when the enemy attack the tower
    public void decreaseHP(float hp)
    {
        currentHP = Mathf.Max(0, currentHP - hp);
    }
    */
}