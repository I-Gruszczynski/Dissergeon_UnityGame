using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Slider healthSlider;
    public Slider healthSliderWhite;
    float time;
    public float healthPlayer = 100;
    public float currentHealth;
    int rand;

    private void Start()
    {
        currentHealth = healthPlayer;
    }

    //int currentHealth;
    /*
    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        //healthSlider.value = currentHealth;
    }
    public void SetHealth( float health, float time)
    {
        
        healthSlider.value = health;
        healthPlayer= health;
        float targetHealth = health;
        float startHealth = healthSlider.value;
        time += Time.deltaTime * 0.25f;
        
        
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, time);
    }
*/
    void Update()
    {

        //currentHealth = player.GetComponent<PlayerHealth>().currnetHealth;
        rand = player.GetComponent<PlayerHealth>().rand;
        time += Time.deltaTime * 0.7f;
        
        if (currentHealth > player.GetComponent<PlayerHealth>().currnetHealth)
        {
            currentHealth -= rand;
            //float smoothCurrentScore = Mathf.Lerp(maxHealth, currentHealth, time);
            time = 0;
            healthSlider.value  = currentHealth;
        }

        if (currentHealth < player.GetComponent<PlayerHealth>().currnetHealth)
        {
            currentHealth += 10;
            //float smoothCurrentScore = Mathf.Lerp(maxHealth, currentHealth, time);
            time = 0;
            healthSlider.value = currentHealth;
        }


        healthSliderWhite.value = Mathf.Lerp(healthSliderWhite.value, currentHealth, time);
        
    }

    public void AniamteHealthBar()
    {
        
        float targetHealth = currentHealth;
        float startHealth = healthSliderWhite.value;


        healthSliderWhite.value = Mathf.Lerp(startHealth, targetHealth, time);
        
    }
    /*
    void TakeDamage(int damage, float time)
    {
        currentHealth -= damage;
        //float smoothCurrentScore = Mathf.Lerp(maxHealth, currentHealth, time);
        healthBar.SetHealth(currentHealth, time);
        //healthBar.AniamteHealthBar(currentHealth);
        //healthBar.AniamteHealthBar(currentHealth);
    }
    */
}
