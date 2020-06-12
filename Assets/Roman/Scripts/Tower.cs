using UnityEngine;

public class Tower : MonoBehaviour
{
    public float currentHP;
    public float maxHP;

    public HealthBar healthBar;

    void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar.UpdateHealthBar(currentHP, maxHP);
        }
    }

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
}