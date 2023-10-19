using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using enemyAttack;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject entity; 
    
    public int maxHealth;
    private int currentHealth;
    public Slider slider;
    void Start()
    {
        slider.maxValue = maxHealth;
        currentHealth = maxHealth;
        slider.value = currentHealth;

    }

    IEnumerator colorChange()
    {
        
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    void Update()
    {
        if (enemyAttack.enemyAttack.isHit  && enemyAttack.enemyAttack.targetTag == entity.tag )
        { 
            sprite.color = Color.red;
            currentHealth = currentHealth - 30;
            slider.value = currentHealth;
            StartCoroutine(colorChange());
        }
        if (attack.attack.isHit  && attack.attack.targetTag == entity.tag )
        {
            sprite.color = Color.red;
            currentHealth = currentHealth - 10;
            slider.value = currentHealth;
            StartCoroutine(colorChange());

        }

        if (currentHealth <= 0)
        {
            if (entity.tag == "Player")
            {
                SceneManager.LoadScene("Lost");
            }
            else if(entity.tag == "enemy")
            {
                SceneManager.LoadScene("Finish");

            }
        }
        
    }
}