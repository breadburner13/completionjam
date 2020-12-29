using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Vector3 spawnpoint;
    private float respawnTimer;
    
    [SerializeField] private float respawnLength;

    [SerializeField] private bool respawn;
    private bool respawning;
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

    public void GainHealth(int gain)
    {
        health = Mathf.Min(health + gain, maxHealth);
    }
    
    public void LoseHealth(int loss)
    {
        health -= loss;
        if (health <= 0)
        {
            Die();
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
