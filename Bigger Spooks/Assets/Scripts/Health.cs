using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
    }

    public void GainHealth(int gain)
    {
        health = Mathf.Min(health + gain, maxHealth);
    }
    
    public void LoseHealth(int loss)
    {
        health = health - loss;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
