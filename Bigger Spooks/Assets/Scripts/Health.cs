using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public Vector3 spawnpoint;
    private float respawnTimer;
    
    [SerializeField] private float respawnLength;

    [SerializeField] private bool respawn;
    private bool respawning;

    [SerializeField] private Transform mask;
    [SerializeField] private Transform healthBar;

    void Start()
    {
        spawnpoint = this.transform.position;
        health = maxHealth;
        respawning = false;
    }

    void Update() 
    {
        if(respawning)
        {
            if(respawnTimer <= 0)
            {
                this.transform.position = spawnpoint;
                health = maxHealth;
                respawning = false;
            }
            else
            {
                respawnTimer -= Time.deltaTime;
            }
        }
        
    }

    private void updateUI()
    {
        if (healthBar)
        {
            float ratio = health / (float)maxHealth;
            var scale = mask.localScale;
            scale.x = ratio;
            mask.localScale = scale;
            var left = healthBar.localPosition;
            left.x -= (healthBar.localScale.x - healthBar.localScale.x * ratio) / 2f;
            left.y = mask.localPosition.y;
            left.z = -1f;
            mask.localPosition = left;
        }
        
    }
    
    public void GainHealth(int gain)
    {
        health = Mathf.Min(health + gain, maxHealth);
        updateUI();
    }
    
    public void LoseHealth(int loss)
    {
        health -= loss;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            updateUI();
        }
    }

    public void Die()
    {
        if(!respawn)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = new Vector3(100000,100000,0);
        respawnTimer = respawnLength;
        respawning = true;
    }
}
