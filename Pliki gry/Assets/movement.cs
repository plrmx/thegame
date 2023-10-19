using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class movement : MonoBehaviour
{
    
    
    public int MovementSpeed;
    public int JumpPower;
    public SpriteRenderer sprite;
    public Sprite jumpSprite;
    public Sprite normalSprite;
    public Sprite attackSprite;
    public Rigidbody2D PlayerRB;
    private int layerMask = 1 << 3;

    
    
    IEnumerator spriteChange()
    {
        
        yield return new WaitForSeconds(0.3f);
        sprite.sprite = normalSprite;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (UnityEngine.Input.GetButton("Horizontal"))
        {
            PlayerRB.velocity =
                new Vector2(MovementSpeed * UnityEngine.Input.GetAxisRaw("Horizontal"), PlayerRB.velocity.y);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.8f, ~layerMask);
        if (hit.collider != null)
        {
            if (UnityEngine.Input.GetButtonDown("Vertical"))
            {
                PlayerRB.velocity =
                    new Vector2(PlayerRB.velocity.x, JumpPower * UnityEngine.Input.GetAxisRaw("Vertical"));
            }
        }

        if (hit.collider == null && !UnityEngine.Input.GetButton("Attack"))
        {
            sprite.sprite = jumpSprite;
        }
        else if(UnityEngine.Input.GetButton("Attack"))
        {
            sprite.sprite = attackSprite;
            StartCoroutine(spriteChange());
        } else
        {
            sprite.sprite = normalSprite;
        }
        
    }
    
}
