using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Change the icon depending on the health.
    public void UpdateHealthBar(float hp)
    {
        if (hp > 66)
        {
            spriteRenderer.sprite = fullHeart;
        }
        else if (hp > 33)
        {
            spriteRenderer.sprite = halfHeart;
        }
        else
        {
            spriteRenderer.sprite = emptyHeart;
        }
    }
}