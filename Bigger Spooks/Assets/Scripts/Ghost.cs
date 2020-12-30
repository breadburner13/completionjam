using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public Furniture currFurniture;
    private float x_input;
    private float y_input;
    private FurnitureManager gm;
    private SpriteRenderer ghostSR;
    private Collider2D ghostCol;
    private Vector3 mousepos;
    public float ghostSpeed;
    public float cooldownLength;
    private float cooldown;
    private Health health;
    [SerializeField]
    private Slider HP;

    [SerializeField] private Text cooldownTimer;
    void Start()
    {
        gm = FindObjectOfType<FurnitureManager>();
        ghostSR = GetComponent<SpriteRenderer>();
        this.ghostSR.enabled = true;
        ghostCol = GetComponent<Collider2D>();
        ghostCol.enabled = true;
        currFurniture = null;
        cooldown = 0;
        health = GetComponent<Health>();
        HP.value = 1;
    }

    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 20;
        this.transform.position = mousepos;
        move();
        if (Input.GetKeyDown("z") && cooldown <= 0)
        {
            this.ghostSR.enabled = true;
            ghostCol.enabled = true;
            if (currFurniture)
            {
                currFurniture.possessed = false;   
            }
            currFurniture = null;
            gm.tracking = this.transform;
            gm.trackingRB = GetComponent<Rigidbody2D>();
        }
        if(cooldown > 0){
            cooldown -= Time.deltaTime;
        }

        cooldownTimer.text = "Cooldown: " + (int) cooldown;
    }

    private void move()
    {
        if(currFurniture)
        {
            currFurniture.furnitureRB.velocity = new Vector2(x_input, y_input).normalized * currFurniture.speed * ghostSpeed;
            //Debug.Log(gm.calculateScore());
        }
    }

    public void possess(Furniture f)
    {
        if (cooldown <= 0)
        {
            this.ghostSR.enabled = false;
            ghostCol.enabled = false;
            if (currFurniture)
            {
                currFurniture.possessed = false;
            }

            currFurniture = f;
            f.possessed = true;
            gm.tracking = currFurniture.transform;
            cooldown = cooldownLength;
            gm.trackingRB = currFurniture.GetComponent<Rigidbody2D>();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();
            updateslider(obstacle.damage);
            health.LoseHealth(obstacle.damage);
        }
    }
    public void updateslider(float dmg)
    {
        HP.value = (health.health - dmg) / health.maxHealth;
    }
}
