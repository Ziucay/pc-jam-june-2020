using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite fullHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite emptyHeartSprite;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private SpriteRenderer spriteRendererHeart1;
    private SpriteRenderer spriteRendererHeart2;
    private SpriteRenderer spriteRendererHeart3;

    private Health health;

    void Start()
    {
        spriteRendererHeart1 = heart1.GetComponent<SpriteRenderer>();
        spriteRendererHeart2 = heart2.GetComponent<SpriteRenderer>();
        spriteRendererHeart3 = heart3.GetComponent<SpriteRenderer>();

        health = GetComponent<Health>();
    }

    // Change the icon depending on the health.
    public void UpdateHealthBar()
    {
        float currentHP = health.health;
        float maxHP = health.maxHealth;


        float percentageHP = 100 * currentHP / maxHP;

        if (percentageHP > 85)
        {
            spriteRendererHeart1.sprite = fullHeartSprite;
            spriteRendererHeart2.sprite = fullHeartSprite;
            spriteRendererHeart3.sprite = fullHeartSprite;
        }
        else if (percentageHP > 70)
        {
            spriteRendererHeart1.sprite = fullHeartSprite;
            spriteRendererHeart2.sprite = fullHeartSprite;
            spriteRendererHeart3.sprite = halfHeartSprite;
        }
        else if (percentageHP > 55)
        {
            spriteRendererHeart1.sprite = fullHeartSprite;
            spriteRendererHeart2.sprite = fullHeartSprite;
            spriteRendererHeart3.sprite = emptyHeartSprite;
        }
        else if (percentageHP > 40)
        {
            spriteRendererHeart1.sprite = fullHeartSprite;
            spriteRendererHeart2.sprite = halfHeartSprite;
            spriteRendererHeart3.sprite = emptyHeartSprite;
        }
        else if (percentageHP > 25)
        {
            spriteRendererHeart1.sprite = fullHeartSprite;
            spriteRendererHeart2.sprite = emptyHeartSprite;
            spriteRendererHeart3.sprite = emptyHeartSprite;
        }
        else if (percentageHP > 10)
        {
            spriteRendererHeart1.sprite = halfHeartSprite;
            spriteRendererHeart2.sprite = emptyHeartSprite;
            spriteRendererHeart3.sprite = emptyHeartSprite;
        }
        else
        {
            spriteRendererHeart1.sprite = emptyHeartSprite;
            spriteRendererHeart2.sprite = emptyHeartSprite;
            spriteRendererHeart3.sprite = emptyHeartSprite;
        }
    }
}