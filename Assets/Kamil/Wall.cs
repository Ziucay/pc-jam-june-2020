using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmdSrpite;
    /*
    public int hp = 4;
    */
    private SpriteRenderer spriteRenderer;
    private Health hpScript;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hpScript = GetComponent<Health>();
        hpScript.OnDeath += DestroyWall;
    }

    void DestroyWall()
    {
        Destroy(this.gameObject);
    }

    /*public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmdSrpite;
        hp -= loss;
        if (hp <= 0) {
            gameObject.SetActive(false);
        }
    }*/

}
