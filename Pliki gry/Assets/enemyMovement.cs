using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Rigidbody2D enemy;
    public Rigidbody2D player;
    private float moveCooldownStart = 3f;
    private float jumpCooldownStart = 3f;
    private float jumpCooldownEnd = 7f;
    private int enemyMask = 1 << 7;
    private RaycastHit2D attack;
    private float moveCooldownEnd = 1f;
    // Start is called before the first frame update
    void Start()
    {
        enemy.velocity = new Vector2(-10f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
       attack = Physics2D.Raycast(transform.position, Vector2.left, 1.1f, ~enemyMask);

       if (player.transform.position.x > enemy.transform.position.x)
       {

           attack = Physics2D.Raycast(transform.position, Vector2.right, 1.5f, ~enemyMask);
           enemy.transform.localScale = new Vector3(1f, 1f, 1f); 
       }
       else if (player.transform.position.x < enemy.transform.position.x)
       {

           attack = Physics2D.Raycast(transform.position, Vector2.left, 1.5f, ~enemyMask);
           enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
       }
        if (Time.time > moveCooldownStart + moveCooldownEnd )
        {
            if (attack.collider == null)
            {
                moveCooldownStart = Time.time;
                enemy.velocity = new Vector2(enemy.velocity.x + UnityEngine.Random.Range(-10.0f, 10.0f), enemy.velocity.y);
            }else if (!attack.collider.CompareTag("Player"))
            {
                moveCooldownStart = Time.time;
                enemy.velocity = new Vector2(enemy.velocity.x +  UnityEngine.Random.Range(-10.0f, 10.0f),  enemy.velocity.y);
            }
        }
        if (Time.time > jumpCooldownStart + jumpCooldownEnd )
        {
            if (attack.collider == null)
            {
                jumpCooldownStart = Time.time;
                enemy.velocity = new Vector2(enemy.velocity.x, UnityEngine.Random.Range(0, 10.0f));
            }else if (!attack.collider.CompareTag("Player"))
            {
                moveCooldownStart = Time.time;
                enemy.velocity = new Vector2(enemy.velocity.x, UnityEngine.Random.Range(0, 10.0f));
            }
        }
    }
}
